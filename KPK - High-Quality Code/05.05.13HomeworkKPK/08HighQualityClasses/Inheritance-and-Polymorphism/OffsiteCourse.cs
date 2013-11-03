using System;
using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
		private string town;

		public OffsiteCourse(string courseName)
			: base(courseName)
		{
		}

		public OffsiteCourse(string courseName, string teacherName)
			: base(courseName, teacherName)
		{
		}

		public OffsiteCourse(string courseName, string teacherName, IList<string> students)
			: base(courseName, teacherName, students)
		{
		}

		public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
			: base(courseName, teacherName, students)
		{
			if (town != null)
			{
				this.Town = town;
			}
			else
			{
				throw new ArgumentNullException("Town can't be null!");
			}
		}

		public string Town
		{
			get
			{
				return this.town;
			}

			set
			{
				if (value != null)
				{
					this.town = value;
				}
				else
				{
					throw new ArgumentNullException("Town can't be null!");
				}
			}
		}

		public override string ToString()
		{
			if (this.Town != null)
			{
				string result = base.ToString() + string.Format("; Town = {0}", this.Town) + " }";
				return result;
			}
			else
			{
				return base.ToString() + " }";
			}
		}
    }
}
