using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace School.Test
{
	[TestClass]
	public class SchoolTest
	{
		[TestMethod]
		public void SchoolConstructor_IsNull()
		{
			List<Course> courses = new List<Course>();
			School school = new School(courses);
			Assert.IsNotNull(school);
		}

		[TestMethod]
		public void AddCourse_IsTrue()
		{
			List<Course> courses = new List<Course>();
			Course css = new Course("CSS");
			School school = new School(courses);
			school.AddCourse(css);
			Assert.AreEqual(css.Name, school.Courses[0].Name);
		}

		[TestMethod]
		public void RemoveCourse_IsTrue()
		{
			List<Course> courses = new List<Course>();
			School school = new School(courses);
			Course html = new Course("HTML");
			school.AddCourse(html);
			school.RemoveCourse(html);
			Assert.IsTrue(school.Courses.Count == 0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException),"The course does not exist. No need to remove it!")]
		public void RemoveCourse_ThrowsExceptionWhenParameterNull()
		{
			List<Course> courses = new List<Course>();
			School school = new School(courses);
			Course javascript = new Course("Javascript");
			school.RemoveCourse(javascript);
		}
	}
}
