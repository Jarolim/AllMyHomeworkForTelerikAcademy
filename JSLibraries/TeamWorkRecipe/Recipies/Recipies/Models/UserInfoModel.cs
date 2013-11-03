using Newtonsoft.Json;
using Recipies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Recipies.Models
{
    public class UserInfoModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        public static Expression<Func<User, UserInfoModel>> FromUser
        {
            get
            {
                return x => new UserInfoModel()
                {
                    Id = x.UserId,
                    Username = x.Username
                };
            }
        }
    }
}