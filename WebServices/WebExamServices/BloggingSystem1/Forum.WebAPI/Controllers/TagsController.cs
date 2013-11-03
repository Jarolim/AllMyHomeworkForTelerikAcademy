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

namespace BloggingSystem.WebAPI.Controllers
{
    public class TagsController : BaseApiController
    {
        //api/tags
        // with X-sessionKey: 1nlXeVeFmmPvlgMVGKvmxSCwDwPvrYtTfFlmuZfhbhwLwkPyiI got from the Database
        [HttpGet]
        public IQueryable<TagModel> GetAllTags(
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

                var tagEntities = context.Tags;
                var models =
                    (from tagEntity in tagEntities
                     select new TagModel()
                     {
                         Id = tagEntity.Id,
                         Name = tagEntity.Name,
                         Posts = tagEntity.Posts.Count,
                     });
                return models.OrderByDescending(t => t.Name);
            });

            return responseMsg;
        }

        //api/tags/{tagId}/posts
        [ActionName("posts")]
        public IQueryable<PostModel> GetPosts(int tagId,
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

                var postEntities = context.Tags.FirstOrDefault(t => t.Id == tagId).Posts;
                //parsing to PostModel

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

            return responseMsg.AsQueryable();

            //TagModel[] models = { new TagModel(){
            //    Id=5,
            //    Name="Banana",
            //    Posts=77,
            //}};
            //return models.AsQueryable();
        }

    }
}

