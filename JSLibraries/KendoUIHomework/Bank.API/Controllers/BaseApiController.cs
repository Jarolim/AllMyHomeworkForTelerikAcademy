using Bank.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bank.API.Controllers
{
    public class BaseApiController : ApiController
    {
        private const int SessionKeyLength = 50;

        protected T PerformOperationAndHandleExceptions<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errResponse);
            }
        }

        protected void ValidateSessionKey(string sessionKey, BankContext context)
        {
            if (sessionKey.Length != SessionKeyLength)
            {
                throw new ArgumentException("The session key is of invalid length!");
            }

            var user = from u in context.Users
                       where u.SessionKey == sessionKey
                       select u;

            if (user == null)
            {
                throw new InvalidOperationException("Session key not found!");
            }
        }
    }
}
