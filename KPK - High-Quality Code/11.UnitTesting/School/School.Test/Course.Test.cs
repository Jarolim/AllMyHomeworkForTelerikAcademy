using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace School.Test
{
	[TestClass]
	public class CourseTest
	{
		[TestMethod]
		public void CourseConstructor_Name()
		{
			string name = "CSS";
			Course course = new Course(name);
			Assert.AreEqual(course.Name, "CSS");
		}

		[TestMethod]
		public void CourseConstructor_ListStudents()
		{
			string name = "Javascript";
			Student samuel = new Student("Samuel Jackson", 12345);
			IList<Student> students = new List<Student>();
			Course course = new Course(name, students);
			course.AddStudent(samuel);
			Assert.IsTrue(course.Students.Contains(samuel));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException),"Course name can not be empty!")]
		public void NameTestNullValue()
		{
			string name = null;
			Course newCourse = new Course(name);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException),"Course name can not be empty!")]
		public void NameTestEmptyString()
		{
			string name = string.Empty;
			Course newCourse = new Course(name);
		}

		[TestMethod]
		public void AddStudent_OneStudent()
		{
			string name = "HTML";
			IList<Student> students = new List<Student>();
			Course course = new Course(name, students);
			Student samuel = new Student("Samuel Jackson", 12345);
			course.AddStudent(samuel);
			Assert.IsTrue(course.Students.Count == 1);
		}

		[TestMethod]
		public void AddStudent_TwoStudents()
		{
			string name = "HTML";
			IList<Student> students = new List<Student>();
			Course course = new Course(name, students);
			Student samuel = new Student("Samuel Jackson", 12345);
			Student emad = new Student("Emad Abdulahad", 23456);
			course.AddStudent(samuel);
			course.AddStudent(emad);
			Assert.IsTrue(course.Students.Count == 2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException), "The student has been added already!")]
		public void AddStudent_SameStudentTwoTimes()
		{
			string name = "Javascript";
			IList<Student> students = new List<Student>();
			Course course = new Course(name, students);
			Student samuel = new Student("Samuel Jackson", 12345);
			course.AddStudent(samuel);
			course.AddStudent(samuel);
		}

		[TestMethod]
		public void RemoveStudent_Removing()
		{
			string name = "Javascript";
			IList<Student> students = new List<Student>();
			Course course = new Course(name, students);
			Student samuel = new Student("Samuel Jackson", 12345);
			Student emad = new Student("Emad Abdulahad", 23445);
			course.AddStudent(samuel);
			course.AddStudent(emad);
			course.RemoveStudent(emad);
			Assert.IsTrue(course.Students.Count == 1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException), "The student does not exist. No need to remove him!")]
		public void RemoveStudent_NonExistingStudent()
		{
			string name = "CSS";
			IList<Student> students = new List<Student>();
			Course course = new Course(name, students);
			Student samuel = new Student("Samuel Jackson", 12345);
			course.RemoveStudent(samuel);
		}
	}
}
