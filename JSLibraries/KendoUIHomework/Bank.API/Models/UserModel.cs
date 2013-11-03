using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Bank.API.Models
{
    public class UserModel
    {
        public string Username { get; set; }

        public string FullName { get; set; }

        public string AuthCode { get; set; }
    }
}