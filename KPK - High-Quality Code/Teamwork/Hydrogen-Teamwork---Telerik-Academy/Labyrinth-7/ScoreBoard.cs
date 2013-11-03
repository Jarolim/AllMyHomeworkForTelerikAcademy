using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    public class ScoreBoard
    {
        private const int Capacity = 5;

        private readonly List<Score> scores;

        public List<Score> Scores
        {
            get 
            {
                List<Score> clonedScores = new List<Score>(Capacity);

                foreach (var item in this.scores)
                {
                    clonedScores.Add(item);
                }

                return clonedScores;
            }
        }

        public ScoreBoard()
        {
            this.scores = new List<Score>(Capacity);
        }

        public void AddNewScore(int moves, string name)
        {
            if (this.scores.Count < Capacity)
            {
                this.scores.Add(new Score(moves, name));
            }
            else if (this.scores.Count == Capacity)
            {
                if (this.scores[4].Moves > moves)
                {
                    this.scores.Remove(scores[4]);
                    this.scores.Add(new Score(moves, name));
                }
            }
            this.scores.Sort();
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine();

            if (this.scores.Count == 0)
            {
                result.AppendLine(Message.ScoreboardEmpty);
            }
            else
            {
                result.AppendLine("Top 5:");
                result.AppendLine();
                for (int i = 0; i < scores.Count; i++)
                {
                    int rankPosition = i + 1;
                    result.AppendFormat("{0}. {2} ---> {1} moves",
                        rankPosition, this.scores[i].Moves, this.scores[i].Name);
                    result.AppendLine();
                }

                result.AppendLine();
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}