using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace School.Test
{
	[TestClass]
	public class StudentTest
	{
		[TestMethod]
		public void StudentConstructor_Name()
		{
			string name = "Samuel Jackson";
			int uniqueID = 12345;
			Student student = new Student(name, uniqueID);
			Assert.AreEqual(student.Name, "Samuel Jackson");
		}

		[TestMethod]
		public void StudentConstructor_UniqueID()
		{
			string name = "Samuel Jackson";
			int uniqueID = 12345;
			Student student = new Student(name, uniqueID);
			Assert.AreEqual(student.UniqueID, 12345);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException), "Student name cannot be empty!")]
		public void NameTestNullValue()
		{
			string name = null;
			int uniqueID = 12345;
			Student student = new Student(name, uniqueID);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException), "Student name cannot be empty!")]
		public void NameTestEmptyString()
		{
			string name = string.Empty;
			int uniqueID = 12345;
			Student student = new Student(name, uniqueID);
		}

		[TestMethod]
		public void UniqueID_StartValue()
		{
			string name = "Samuel Jackson";
			int uniqueID = 10000;
			Student student = new Student(name, uniqueID);
			Assert.IsTrue(uniqueID >= 10000 && uniqueID <= 99999);
		}

		[TestMethod]
		public void UniqueID_EndValue()
		{
			string name = "Samuel Jackson";
			int uniqueID = 99999;
			Student student = new Student(name, uniqueID);
			Assert.IsTrue(uniqueID >= 10000 && uniqueID <= 99999);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void uniqueIDTestStartValueMinusOne()
		{
			string name = "Samuel Jackson";
			int uniqueID = 9999;
			Student student = new Student(name, uniqueID);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "The unique number of student should be between 10000 and 99999!")]
		public void UniqueID_EndValuePlusOne()
		{
			string name = "Samuel Jackson";
			int uniqueID = 100000;
			Student student = new Student(name, uniqueID);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "The unique number of student should be between 10000 and 99999!")]
		public void UniqueID_EndValuePlus10000()
		{
			string name = "Samuel Jackson";
			int uniqueID = 109999;
			Student student = new Student(name, uniqueID);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "The unique number of student should be between 10000 and 99999!")]
		public void UniqueID_Zero()
		{
			string name = "Samuel Jackson";
			int uniqueID = 0;
			Student student = new Student(name, uniqueID);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "The unique number of student should be between 10000 and 99999!")]
		public void UniqueID_IntMaxValue()
		{
			string name = "Samuel Jackson";
			int uniqueID = int.MaxValue;
			Student student = new Student(name, uniqueID);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "The unique number of student should be between 10000 and 99999!")]
		public void UniqueID_NegativeValue()
		{
			string name = "Samuel Jackson";
			int uniqueID = -12345;
			Student student = new Student(name, uniqueID);
		}

	}
}
