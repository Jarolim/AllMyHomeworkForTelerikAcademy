using Bank.API.Models;
using Bank.Context;
using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bank.API.Controllers
{
    public class AccountsController : BaseApiController
    {
        // GET api/accounts?sessionKey=6ilMDVNERfNoSdvBYnOUgItiImNsSrtkZxEzpnbTXfSgXpmmMD
        [HttpGet]
        public HttpResponseMessage GetAccountsBySessionKey(string sessionKey)
        {
            var response = this.PerformOperationAndHandleExceptions(() =>
            {
                BankContext context = new BankContext();
                this.ValidateSessionKey(sessionKey, context);

                var accounts = (from account in context.Accounts.Include("Owner")
                                where account.Owner.SessionKey == sessionKey
                                select new AccountModel()
                                {
                                    Id = account.Id,
                                    Balance = account.Balance,
                                    OwnerName = account.Owner.FullName
                                });

                var responseMsg = this.Request.CreateResponse(HttpStatusCode.OK, accounts);

                return responseMsg;
            });

            return response;
        }

        // GET api/accounts/5?sessionKey=6ilMDVNERfNoSdvBYnOUgItiImNsSrtkZxEzpnbTXfSgXpmmMD
        [HttpGet]
        public HttpResponseMessage GetDetailedInformationAboutAnAccount(int id, string sessionKey)
        {
            var response = this.PerformOperationAndHandleExceptions(() =>
            {
                BankContext context = new BankContext();
                this.ValidateSessionKey(sessionKey, context);

                var acc = (from account in context.Accounts.Include("Owner")
                           where account.Id == id && account.Owner.SessionKey == sessionKey
                           select new FullAccountModel()
                           {
                               Id = account.Id,
                               Balance = account.Balance,
                               CreatedOn = account.CreatedOn,
                               ExpireDate = account.ExpireDate,
                               Owner = new LoggedUserModel()
                               {
                                   FullName = account.Owner.FullName,
                                   SessionKey = account.Owner.SessionKey
                               },
                               Transactions = from transaction in account.Transactions
                                               select new TransactionLogModel()
                                               {
                                                   AccountId = account.Id,
                                                   LogDate = transaction.LogDate,
                                                   LogText = transaction.LogText,
                                                   UserFullName = account.Owner.FullName
                                               }
                           });

                var responseMsg = this.Request.CreateResponse(HttpStatusCode.OK, acc);

                return responseMsg;
            });

            return response;
        }

        // PUT api/accounts/5?sessionKey=6ilMDVNERfNoSdvBYnOUgItiImNsSrtkZxEzpnbTXfSgXpmmMD&depositSum=123.32
        [HttpPut]
        public HttpResponseMessage DepositCash(int id, decimal depositSum, string sessionKey)
        {
            var response = this.PerformOperationAndHandleExceptions(() =>
            {
                BankContext context = new BankContext();
                this.ValidateSessionKey(sessionKey, context);

                var acc = (from account in context.Accounts.Include("Owner")
                           where account.Id == id && account.Owner.SessionKey == sessionKey
                           select account).FirstOrDefault();

                if (acc == null)
                {
                    throw new ArgumentException("Account not found.");
                }

                TransactionLog transactionLog = new TransactionLog()
                {
                    Account = acc,
                    LogDate = DateTime.Now,
                    LogText = string.Format("{0} deposited {1} money in {2}", acc.Owner.FullName, depositSum, acc.Id)
                };

                acc.Transactions.Add(transactionLog);
                context.TransactionLogs.Add(transactionLog);

                acc.Balance += depositSum;
                context.SaveChanges();

                var responseMsg = this.Request.CreateResponse(HttpStatusCode.OK);

                return responseMsg;
            });

            return response;
        }

        // PUT api/accounts/5?sessionKey=6ilMDVNERfNoSdvBYnOUgItiImNsSrtkZxEzpnbTXfSgXpmmMD&withdrawSum=123.32
        [HttpPut]
        public HttpResponseMessage WithdrawCash(int id, decimal withdrawSum, string sessionKey)
        {
            var response = this.PerformOperationAndHandleExceptions(() =>
            {
                BankContext context = new BankContext();
                this.ValidateSessionKey(sessionKey, context);

                var acc = (from account in context.Accounts.Include("Owner")
                           where account.Id == id && account.Owner.SessionKey == sessionKey
                           select account).FirstOrDefault();

                if (acc == null)
                {
                    throw new ArgumentException("Account not found.");
                }

                if (acc.Balance - withdrawSum < 0)
                {
                    throw new ArgumentException("Not enough cash.");
                }

                TransactionLog transactionLog = new TransactionLog()
                {
                    Account = acc,
                    LogDate = DateTime.Now,
                    LogText = string.Format("{0} withdrawed {1} money in {2}", acc.Owner.FullName, withdrawSum, acc.Id)
                };

                acc.Transactions.Add(transactionLog);
                context.TransactionLogs.Add(transactionLog);

                acc.Balance -= withdrawSum;
                context.SaveChanges();

                var responseMsg = this.Request.CreateResponse(HttpStatusCode.OK);

                return responseMsg;
            });

            return response;
        }

        //// POST api/accounts
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/accounts/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/accounts/5
        //public void Delete(int id)
        //{
        //}
    }
}
