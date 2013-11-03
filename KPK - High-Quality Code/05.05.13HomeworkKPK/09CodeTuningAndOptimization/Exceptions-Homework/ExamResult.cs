using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
			throw new ArgumentOutOfRangeException("Grades can't be negative!");
        }
        if (minGrade < 0)
        {
			throw new ArgumentOutOfRangeException("Grades can't be negative!");
        }
        if (maxGrade <= minGrade)
        {
			throw new ArgumentException("The maximum grade can't be smaller then the minimum grade!");
        }
        if (comments == null || comments == string.Empty)
        {
			throw new ArgumentNullException("Please add comments to the grades!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
