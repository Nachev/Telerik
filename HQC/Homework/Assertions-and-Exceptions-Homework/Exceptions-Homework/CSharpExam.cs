namespace ExceptionsHomework
{
    using System;

    public class CSharpExam : Exam
    {
        private const int MaxScores = 100;
        private const int MinScores = 0;
        public int Score { get; private set; }

        public CSharpExam(int score)
        {
            if (score < MinScores)
            {
                throw new ArgumentException("Score value cannot be negative!");
            }

            this.Score = score;
        }

        public override ExamResult Check()
        {
            if (Score < MinScores || Score > MaxScores)
            {
                throw new ArgumentOutOfRangeException("Score value must be in range " + MinScores + " to " + MaxScores);
            }
            else
            {
                return new ExamResult(this.Score, MinScores, MaxScores, "Exam results calculated by score.");
            }
        }
    }
}
