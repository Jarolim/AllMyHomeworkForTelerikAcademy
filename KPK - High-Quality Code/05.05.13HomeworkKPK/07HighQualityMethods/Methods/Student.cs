using System;

namespace Methods
{
    public class Student
    {
        public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public string OtherInfo { get; private set; }
		public DateTime BirthDate { get; private set; } //added

		public Student(string firstName, string lastName, string otherInfo, string birthDate) //added constructor
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.OtherInfo = otherInfo;
			this.BirthDate = DateTime.Parse(birthDate);
		}

        public bool IsOlderThan(Student otherStudent)
        {
			
			DateTime firstBirthDate = this.BirthDate;
			DateTime secondBirthDate = otherStudent.BirthDate;
			bool isOlder = firstBirthDate < secondBirthDate; //changed to be accurate (the sooner you are born the older you are :) )

			return isOlder;
        }
    }
}
