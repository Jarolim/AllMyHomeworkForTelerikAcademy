using System;
using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
	public class LocalCourse : Course
	{
		private string lab;

		public LocalCourse(string courseName) : base(courseName)
		{
		}

		public LocalCourse(string courseName, string teacherName) : base(courseName, teacherName)
		{
		}

		public LocalCourse(string courseName, string teacherName, IList<string> students) : base(courseName, teacherName, students)
		{
		}

		public LocalCourse(string courseName, string teacherName, IList<string> students, string lab) : base(courseName, teacherName, students)
		{
			if (lab != null)
			{
				this.Lab = lab;
			}
			else
			{
				throw new ArgumentNullException("Lab can't be null!");
			}
		}

		public string Lab
		{
			get
			{
				return this.lab;
			}

			set
			{
				if (value != null)
				{
					this.lab = value;
				}
				else
				{
					throw new ArgumentNullException("Lab can't be null!");
				}
			}
		}

		public override string ToString()
		{
			if (this.Lab != null)
			{
				string result = base.ToString() + string.Format("; Lab = {0}", this.Lab) + " }";
				return result;
			}
			else
			{
				return base.ToString() + " }";
			}
		}
	}
}
