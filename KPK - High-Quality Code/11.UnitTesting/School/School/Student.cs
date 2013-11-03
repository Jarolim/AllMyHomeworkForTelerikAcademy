using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
	public class Student
	{
		private string name;
		private int uniqueID;
		private static int nextID = 10000;

		public Student(string name, int uniqueID)
		{
			this.Name = name;
			this.UniqueID = uniqueID;
		}

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
					throw new ArgumentNullException("Student name cannot be empty!");
				}
				else
				{
					this.name = value;
				}
			}
		}

		public int UniqueID
		{
			get
			{
				return this.uniqueID;
			}

			set
			{
				if (value >= nextID && value <= 99999)
				{
					this.uniqueID = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("The unique number of student should be between 10000 and 99999!");
				}
			}
		}

		
	}
}
