using Recipies.Data;
using Recipies.Models;
using Recipies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Net;

namespace Recipies.Controllers
{
    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLenght = 30;
        private const string ValidUsernameCharacters =
            "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890_.";
        private const string SessionKeyChars =
            "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";

        private static readonly Random rand = new Random();

        private const int Sha1Length = 40;
        private const int SessionKeyLength = 50;

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var dbContext = new RecipesContext();
                using (dbContext)
                {
                    this.ValidateUsername(model.Username);
                    this.ValidateAuthCode(model.AuthCode);

                    var usernameToLower = model.Username.ToLower();

                    var user = dbContext.Users.FirstOrDefault(
                        usr => usr.Username == usernameToLower);

                    if (user != null)
                    {
                        throw new InvalidOperationException("User exists");
                    }

                    user = new User()
                    {
                        Username = model.Username.ToLower(),
                        AuthCode = model.AuthCode,
                        Role = Role.Client
                    };

                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();

                    user.SessionKey = this.GenerateSessionKey(user.UserId);
                    dbContext.SaveChanges();

                    var loggedModel = new LoggedUserModel()
                    {
                        Username = user.Username,
                        SessionKey = user.SessionKey
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);
                    return response;
                }
            });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var dbContext = new RecipesContext();
                using (dbContext)
                {
                    this.ValidateUsername(model.Username);
                    this.ValidateAuthCode(model.AuthCode);

                    var usernameToLower = model.Username.ToLower();

                    var user = dbContext.Users.FirstOrDefault(
                        usr => usr.Username == usernameToLower
                        && usr.AuthCode == model.AuthCode);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username or password");
                    }

                    if (user.SessionKey == null)
                    {
                        user.SessionKey = this.GenerateSessionKey(user.UserId);
                        dbContext.SaveChanges();
                    }

                    var loggedModel = new LoggedUserModel()
                    {
                        Username = user.Username,
                        SessionKey = user.SessionKey
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);
                    return response;
                }
            });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage PutLogoutUser()
        {
            var dbContext = new RecipesContext();
            using (dbContext)
            {
                var user =  GetCurrentUser(dbContext);
                if (user != null)
                {
                    user.SessionKey = null;
                    dbContext.SaveChanges();
                }

                var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
                return response;
            }
        }

        [HttpPut]
        [ActionName("promote")]
        public HttpResponseMessage PromoteUser(int id)
        {
            var dbContext = new RecipesContext();
            using (dbContext)
            {
                var user = GetCurrentUser(dbContext);
                if (user == null || user.Role != Role.Admin)
                {
                    throw new InvalidOperationException("Only an authorized admin can promote users.");
                }

                var userToPromote = dbContext.Users.FirstOrDefault(u => u.UserId == id);

                if (userToPromote != null)
                {
                    userToPromote.Role = Role.Admin;
                    dbContext.SaveChanges();
                }

                var response = this.Request.CreateResponse(HttpStatusCode.OK, string.Empty);
                return response;
            }
        }

        [HttpPut]
        [ActionName("delete")]
        public HttpResponseMessage DeleteUser(int id)
        {
            var dbContext = new RecipesContext();
            using (dbContext)
            {
                var user = GetCurrentUser(dbContext);
                if (user == null || user.Role != Role.Admin)
                {
                    throw new InvalidOperationException("Only an authorized admin can delete users.");
                }

                var userToDelete = dbContext.Users.FirstOrDefault(u => u.UserId == id);

                if (userToDelete != null)
                {
                    dbContext.Users.Remove(userToDelete);
                    dbContext.SaveChanges();
                }

                var response = this.Request.CreateResponse(HttpStatusCode.OK, string.Empty);
                return response;
            }
        }

        [HttpPut]
        [ActionName("update")]
        public HttpResponseMessage UpdateUser(int id, UserModel model)
        {
            var dbContext = new RecipesContext();
            using (dbContext)
            {
                var user = GetCurrentUser(dbContext);
                if (user == null || user.Role != Role.Admin)
                {
                    throw new InvalidOperationException("Only an authorized admin can delete users.");
                }

                var userToUpdate = dbContext.Users.FirstOrDefault(u => u.UserId == id);

                if (userToUpdate != null)
                {
                    if (model.AuthCode != null)
                    {
                        ValidateAuthCode(model.AuthCode);
                        userToUpdate.AuthCode = model.AuthCode;
                        dbContext.SaveChanges(); 
                    }
                }

                var response = this.Request.CreateResponse(HttpStatusCode.OK, string.Empty);
                return response;
            }
        }

        [HttpGet]
        [ActionName("get")]
        public IQueryable<UserInfoModel> GetAll() 
        {
            var dbContext = new RecipesContext();
            var user = GetCurrentUser(dbContext);
            if (user == null || user.Role != Role.Admin)
            {
                throw new InvalidOperationException("Only an authorized admin can view users.");
            }

            var users = dbContext.Users.Select(UserInfoModel.FromUser);
            return users;
            
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder sessionKeyBuilder = new StringBuilder(SessionKeyLength);
            sessionKeyBuilder.Append(userId);
            while (sessionKeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                sessionKeyBuilder.Append(SessionKeyChars[index]);
            }


            return sessionKeyBuilder.ToString();
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1Length)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted");
            }
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username connot be null");
            }
            else if (username.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be atleast {0} characters long",
                    MinUsernameLength));
            }
            else if (username.Length > MaxUsernameLenght)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be less than {0} characters long",
                    MaxUsernameLenght));
            }
            else if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only Latin letters, digits .,_");
            }
        }
    }
}