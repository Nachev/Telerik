namespace ExceptionsHomework
{
    using System;
    public class SimpleMathExam : Exam
    {
        private const int MinGrade = 2;
        private const int MaxGrade = 6;
        private const int NumberOfProblems = 2;

        public int ProblemsSolved { get; private set; }

        public SimpleMathExam(int problemsSolved)
        {
            if (problemsSolved < 0)
            {
                throw new ArgumentException("Problems solved value cannot be negative!");
            }
            if (problemsSolved > NumberOfProblems)
            {
                throw new ArgumentException("Problems solved value cannot be greater than" + NumberOfProblems + "!");
            }

            this.ProblemsSolved = problemsSolved;
        }

        public override ExamResult Check()
        {
            if (ProblemsSolved == 0)
            {
                return new ExamResult(2, MinGrade, MaxGrade, "Bad result: nothing done.");
            }
            else if (ProblemsSolved == 1)
            {
                return new ExamResult(4, MinGrade, MaxGrade, "Average result: nothing done.");
            }
            else if (ProblemsSolved == NumberOfProblems)
            {
                return new ExamResult(6, MinGrade, MaxGrade, "Average result: nothing done.");
            }

            return new ExamResult(0, MinGrade, MaxGrade, "Invalid number of problems solved!");
        }
    }
}
