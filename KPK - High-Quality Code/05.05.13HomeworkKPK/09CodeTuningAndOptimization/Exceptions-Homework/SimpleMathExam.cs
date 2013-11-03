﻿using System;

public class SimpleMathExam : Exam
{
    public int ProblemsSolved { get; private set; }

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0)
        {
			throw new ArgumentOutOfRangeException("The solved problems can't be a negative number!");
        }

		int maxProblems = 10;
		if (problemsSolved > maxProblems)
        {
			throw new ArgumentOutOfRangeException(string.Format("The solved problems can't be more than {0}!", maxProblems));
        }

        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {
        if (ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }

		throw new ArgumentOutOfRangeException("The number of solved problems is invalid!");
    }
}
