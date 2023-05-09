using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Pmu_Course_Work
{
    public static class Globals
    {
        public static List<Question> questions = new List<Question>();
        public static int questionId = 0;
        public static int correctAnswers = 0;

        public static Locale locale;

        private static Random rand = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
