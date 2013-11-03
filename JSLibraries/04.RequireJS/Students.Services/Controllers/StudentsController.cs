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
        Student[] students;

        public StudentsController()
        {
            this.students = new Student[]{
                new Student(){
                    Id = 1,
                    Name = "Niki Kostov",
                    Grade = 6,
                    Marks = new MarkModel[]{
                        new MarkModel(){
                            Value = 6,
                            Subject = "C#"
                        },
                        new MarkModel(){
                            Value = 5,
                            Subject = "JavaScript"
                        },
                    }
                },
                new Student(){
                    Id = 2,
                    Name = "Doncho Minkov",
                    Grade = 3,
                    Marks = new MarkModel[]{

                        new MarkModel(){
                            Value = 6,
                            Subject = "JavaScript"
                        }
                    }
                },
                new Student(){
                    Id = 3,
                    Name = "Joro Georgiev",
                    Grade = 5,
                    Marks = new MarkModel[]{
                        new MarkModel(){
                            Value = 5,
                            Subject = "C#"
                        },
                        new MarkModel(){
                            Value = 5,
                            Subject = "JavaScript"
                        },
                        new MarkModel(){
                            Value = 6,
                            Subject = "HTML Basics"
                        },
                    }
                },
                new Student(){
                    Id = 4,
                    Name = "Samuel Jackson",
                    Grade = 12,
                    Marks = new MarkModel[]{
                        new MarkModel(){
                            Value = 6,
                            Subject = "Immortality"
                        },
                        new MarkModel(){
                            Value = 6,
                            Subject = "Awesomeness"
                        },
                        new MarkModel(){
                            Value = 6,
                            Subject = "Coolness"
                        },
                    }
                },
                new Student(){
                    Id = 5,
                    Name = "Noone",
                    Grade = 12
                },
            };
        }
        // GET api/students
        public IEnumerable<StudentModel> Get()
        {
            var sent = new StudentModel[]{
                new StudentModel(){
                    Id = students[0].Id,
                    Name = students[0].Name,
                    Grade = students[0].Grade
                },
                new StudentModel(){
                    Id = students[1].Id,
                    Name = students[1].Name,
                    Grade = students[1].Grade
                },
                new StudentModel(){
                    Id = students[2].Id,
                    Name = students[2].Name,
                    Grade = students[2].Grade
                },
                new StudentModel(){
                    Id = students[3].Id,
                    Name = students[3].Name,
                    Grade = students[3].Grade
                },
                new StudentModel(){
                    Id = students[4].Id,
                    Name = students[4].Name,
                    Grade = students[4].Grade
                },
            };

            return sent;
        }

        [ActionName("getmarks")]
        public IEnumerable<MarkModel> Get(int studentId)
        {
            var found = (from s in students
                         where s.Id == studentId
                         select s).FirstOrDefault();

            return found.Marks;
        }

        
    }
}
