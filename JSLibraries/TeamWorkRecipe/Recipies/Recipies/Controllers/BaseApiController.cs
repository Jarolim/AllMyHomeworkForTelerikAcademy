using Recipies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Recipies.Model;

namespace Recipies.Controllers
{
    public class BaseApiController : ApiController
    {
        protected T PerformOperationAndHandleExceptions<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                throw new HttpResponseException(errResponse);
            }
        }

        protected User GetCurrentUser(RecipesContext context)
        {
            var sessionKey = this.Request.Headers.GetValues("X-sessionKey").FirstOrDefault();

            //sessionKey = sessionKey.Substring("sessionKey=".Length);
            if (sessionKey == null)
            {
                throw new InvalidOperationException("No session key found.");
            }

            var user = context.Users.FirstOrDefault(
                usr => usr.SessionKey == sessionKey);

            if (user == null)
            {
                throw new InvalidOperationException("Invalid session key.");
            }

            return user;
        }
    }
}
