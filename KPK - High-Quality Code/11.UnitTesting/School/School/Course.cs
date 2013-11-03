using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
	public class Course
	{
		public const byte MaxStudentsCountInCourse = 29;

		private string name;

		public Course(string name, IList<Student> students = null)
		{
			this.Students = new List<Student>();
			this.Name = name;
		}

		public List<Student> Students { get; set; }

		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException("Course name can not be empty!");
				}
				else
				{
					this.name = value;
				}
			}
		}

		public void AddStudent(Student student)
		{
			bool studentFound = this.CheckIfStudentIsFound(student);

			if (studentFound)
			{
				throw new ArgumentException("The student has been added already!");
			}

			if (this.Students.Count + 1 <= MaxStudentsCountInCourse)
			{
				this.Students.Add(student);
			}
			else
			{
				throw new ArgumentOutOfRangeException("The course is full. No more students can be added!");
			}
		}

		public void RemoveStudent(Student student)
		{
			bool studentFound = this.CheckIfStudentIsFound(student);

			if (!studentFound)
			{
				throw new ArgumentException("The student does not exist. No need to remove him!");
			}

			this.Students.Remove(student);
		}

		private bool CheckIfStudentIsFound(Student student)
		{
			bool studentFound = false;
			for (int i = 0; i < this.Students.Count; i++)
			{
				if (this.Students[i].UniqueID == student.UniqueID)
				{
					studentFound = true;
				}
			}

			return studentFound;
		}
	}
}
