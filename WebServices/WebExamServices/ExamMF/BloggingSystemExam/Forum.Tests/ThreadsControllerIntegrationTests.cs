﻿using System;
using System.Net.Http;
using System.Transactions;
using Forum.WebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using Forum.WebAPI.Controllers;

namespace Forum.Tests
{
    [TestClass]
    public class ThreadsControllerIntegrationTests
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {

            var type = typeof(UsersController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                //new Route(
                //    "ThreadsApi",
                //    "api/threads/{threadId}/posts",
                //    new
                //    {
                //        controller = "threads",
                //        action ="posts"
                //    }),
                //new Route(
                //     "UsersApi",
                //     "api/users/{action}",
                //     new
                //        {
                //            controller = "users"
                //        }),
                        
                new Route(
                    "DefaultApi",
                    "api/{controller}/{id}",
                    new { id = RouteParameter.Optional }),
            };
            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void Register_WhenUserModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
                 {
                     Username = "VALIDUSER",
                     DisplayName = "VALIDNICK",
                     AuthCode = new string('b', 40)
                 };
            //var httpServer = new InMemoryHttpServer("http://localhost/");
            var model = this.RegisterTestUser(httpServer, testUser);
            Assert.AreEqual(testUser.DisplayName, model.DisplayName);
            Assert.IsNotNull(model.SessionKey);
        }

        //[TestMethod]
        //public void GetAll_WhenDataInDatabase_ShouldReturnData()
        //{
        //    var testUser = new UserModel()
        //    {
        //        Username = "VALIDUSER",
        //        DisplayName = "VALIDNICK",
        //        AuthCode = new string('b', 40)
        //    };
        //    LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);
        //    var headers = new Dictionary<string, string>();
        //    headers["X-sessionKey"] = userModel.SessionKey;
        //    var response = httpServer.Get("api/threads", headers);

        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //    Assert.IsNotNull(response.Content);                        
        //}

        private LoggedUserModel RegisterTestUser(InMemoryHttpServer httpServer, UserModel testUser)
        {
            var response = httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);
            return userModel;
        }
    }
}
