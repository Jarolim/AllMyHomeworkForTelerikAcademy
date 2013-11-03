using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Recipies.Models
{
    public class LoggedUserModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("sessionKey")]
        public string SessionKey { get; set; }
    }
}