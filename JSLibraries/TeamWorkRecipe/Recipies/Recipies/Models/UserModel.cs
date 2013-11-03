using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Recipies.Models
{
    public class UserModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("authCode")]
        public string AuthCode { get; set; }
    }
}