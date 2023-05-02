using System;
using System.Collections.Generic;
using System.Text;

namespace Pmu_Course_Work
{
    public class Question
    {
        public string question;
        public List<string> answer;
        public string correctAnswer;

        public Question(string question, List<string> answers)
        {
            this.question = question;
            this.answer = answers;

            this.correctAnswer = answers[0];
            this.answer.Shuffle();
        }
    }
}
