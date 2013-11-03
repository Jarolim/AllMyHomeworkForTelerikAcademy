using DataLayer;
using BloggingSystem.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using BloggingSystem.WebAPI.Attributes;
using BloggingSystem.Model;

namespace BloggingSystem.WebAPI.Controllers
{
    public class PostsController : BaseApiController
    {
        //api/posts
        // with X-sessionKey: 1nlXeVeFmmPvlgMVGKvmxSCwDwPvrYtTfFlmuZfhbhwLwkPyiI got from the Database
        [HttpGet]
        public IQueryable<PostModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystemContext();

                var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password");
                }

                var postEntities = context.Posts;
                var models =
                    (from postEntity in postEntities
                     select new PostModel()
                     {
                         Id = postEntity.Id,
                         Title = postEntity.Title,
                         PostDate = postEntity.PostDate,
                         Text = postEntity.Text,
                         PostedBy = postEntity.User.DisplayName,
                         Comments = (from commentEntity in postEntity.Comments
                                     select new CommentModel()
                                     {
                                         Text = commentEntity.Text,
                                         PostDate = commentEntity.PostDate,
                                         CommentedBy = commentEntity.User.DisplayName
                                     }),
                         Tags = (from tagEntity in postEntity.Tags
                                 select tagEntity.Name)
                     });
                return models.OrderByDescending(p => p.PostDate);
            });

            return responseMsg;
        }

        //api/posts?page=P&count=C
        public IQueryable<PostModel> GetPage(int page, int count,
           string sessionKey)
        {
            var models = this.GetAll(sessionKey)
                .Skip(page * count)
                .Take(count);
            return models;
        }

        //api/posts?keyword=web-services
        public IQueryable<PostModel> GetByKeyword(string keyword,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var models = this.GetAll(sessionKey)
                .Where(p => p.Title.Contains(keyword));
            return models.OrderByDescending(p => p.PostDate);
        }

        //api/posts?tags=web,services
        public IQueryable<PostModel> GetByTags(string allTags,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {

            string[] tags = null;
            tags = allTags.Split(',');

            var models = this.GetAll(sessionKey)
            .Where(p => p.Tags.Any(t => t == tags[0] && t == tags[1]));

            return models.OrderByDescending(p => p.PostDate);
        }

        //api/posts/{postId}/comment
        [ActionName("comment")]
        public HttpResponseMessage PutComments(int postId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystemContext();

                var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password");
                }

                var commentEntities = context.Posts.FirstOrDefault(p => p.Id == postId).Comments;

                if (commentEntities != null)
                {
                    commentEntities = commentEntities;
                    context.SaveChanges();
                }
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
            return responseMsg;


            //var context = new ForumContext();

            //var postEntities = context.Threads.FirstOrDefault(thr => thr.Id == threadId).Posts;
            ////parsing to PostModel

            //CommentModel[] models = { new CommentModel(){
            //    Text="First",
            //    PostDate= DateTime.Now,
            //    CommentedBy="Bai Gosho",
            //}};
            //return models.AsQueryable();
        }
    }
}
