using Students.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        // GET api/students
        public HttpResponseMessage Get()
        {
            StudentModel[] students = new StudentModel[]
            {
                new StudentModel()
                {
                    FirstName = "Doncho",
                    LastName = "Minkov",
                    Marks =  new MarkModel[] {
                        new MarkModel()
                        {
                            Subject = "JS",
                            Score = 5.5
                        }, 
                        new MarkModel()
                        {
                            Subject = "Math",
                            Score = 3
                        },
                        new MarkModel()
                        {
                            Subject = "CSS",
                            Score = 6
                        },
                    }
                },
                new StudentModel()
                {
                    FirstName = "Svetlin",
                    LastName = "Nakov",
                    Marks =  new MarkModel[] {
                        new MarkModel()
                        {
                            Subject = "C#",
                            Score = 5.4
                        },
                        new MarkModel()
                        {
                            Subject = "JavaScript",
                            Score = 4
                        },
                        new MarkModel()
                        {
                            Subject = "Mind Map",
                            Score = 6
                        },
                    }
                },
                new StudentModel()
                {
                    FirstName = "Samuel",
                    LastName = "Jackson",
                    Marks =  new MarkModel[] {
                        new MarkModel()
                        {
                            Subject = "Jedy",
                            Score = 6
                        },
                        new MarkModel()
                        {
                            Subject = "Acting",
                            Score = 6
                        },
                        new MarkModel()
                        {
                            Subject = "Coolness",
                            Score = 6
                        },
                        new MarkModel()
                        {
                            Subject = "Immortality",
                            Score = 6
                        },
                    }
                },
                new StudentModel()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    
                },
            };

            var responce = Request.CreateResponse(HttpStatusCode.OK, students, "application/json");

            return responce;
        }
    }
}
