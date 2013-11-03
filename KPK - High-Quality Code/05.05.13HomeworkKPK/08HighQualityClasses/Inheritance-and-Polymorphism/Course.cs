using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
	public abstract class Course
	{
		private string courseName;
		private string teacherName;
		private IList<string> students = new List<string>();

		protected Course(string courseName)
		{
			if (courseName != null)
			{
				this.CourseName = courseName;
			}
			else
			{
				throw new ArgumentNullException("Course name can't be null!");
			}
		}

		protected Course(string courseName, string teacherName)
			: this(courseName)
		{
			if (teacherName != null)
			{
				this.TeacherName = teacherName;
			}
			else
			{
				throw new ArgumentNullException("Teachers name can't be null!");
			}
		}

		protected Course(string courseName, string teacherName, IList<string> students)
			: this(courseName, teacherName)
		{
			this.Students = students;
		}

		public string CourseName
		{
			get
			{
				return this.courseName;
			}

			set
			{
				if (value != null)
				{
					this.courseName = value;
				}
				else
				{
					throw new ArgumentNullException("Course name can't be null!");
				}
			}
		}

		public string TeacherName
		{
			get
			{
				return this.teacherName;
			}

			set
			{
				if (value != null)
				{
					this.teacherName = value;
				}
				else
				{
					throw new ArgumentNullException("Teachers name can't be null!");
				}
			}
		}

		public IList<string> Students
		{
			get
			{
				return this.students;
			}

			set
			{
				if (value != null)
				{
					this.students = value;
				}
				else
				{
					throw new ArgumentNullException("Students list can't be null!");
				}
			}
		}

		protected string GetStudentsAsString()
		{
			if (this.Students == null || this.Students.Count == 0)
			{
				return "{ }";
			}
			else
			{
				return "{ " + string.Join(", ", this.Students) + " }";
			}
		}

		public override string ToString()
		{
			StringBuilder result = new StringBuilder();
			result.Append(this.GetType().Name);
			result.Append(" { Name = ");
			result.Append(this.CourseName);
			if (this.TeacherName != null)
			{
				result.Append("; Teacher = ");
				result.Append(this.TeacherName);
			}

			result.Append("; Students = ");
			result.Append(this.GetStudentsAsString());

			return result.ToString();
		}
	}
}
