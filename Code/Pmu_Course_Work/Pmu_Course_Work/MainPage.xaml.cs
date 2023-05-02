using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading;

namespace Pmu_Course_Work
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitVars();
            InitializeComponent();
            ExplainApp();
        }

        private void InitVars()
        {
            Globals.questions.Add(new Question("Колко километра е най-дългата българска река?",
                                  new List<string>() { "368 километра", "168 километра", "298 километра", "490 километра" }));
            Globals.questions.Add(new Question("Как се нарича първата българска конституция?",
                                  new List<string>() { "Търновска", "Стамболовска", "Софийска", "Стефанова" }));

            Globals.questions.Shuffle();

            Globals.questionId = 0;
            Globals.correctAnswers = 0;
        }

        void StartQuiz(object sender, EventArgs args)
        {
            QuestionPage questionPage = new QuestionPage();

            Navigation.PushModalAsync(questionPage);
        }

        public async void ExplainApp()
        {
            var locales = await TextToSpeech.GetLocalesAsync();

            var locale = locales.FirstOrDefault();

            var settings = new SpeechOptions()
            {
                Locale = locale
            };

            await TextToSpeech.SpeakAsync("Ще ти бъдат зададени 15 въпроса, за да определим колко добре познаваш България.", settings).ContinueWith((t) =>
            {
                PageButton.IsEnabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
