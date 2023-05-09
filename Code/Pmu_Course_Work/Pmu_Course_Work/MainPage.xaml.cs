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

        private async void InitVars()
        {
            Globals.questions.Shuffle();

            Globals.questionId = 0;
            Globals.correctAnswers = 0;
        }

        void StartQuiz(object sender, EventArgs args)
        {
            QuestionPage questionPage = new QuestionPage();

            Navigation.PushModalAsync(questionPage);
        }

        private async void ExplainApp()
        {
            var settings = new SpeechOptions()
            {
                Locale = Globals.locale
            };

            await TextToSpeech.SpeakAsync("Ще ти бъдат зададени 10 въпроса, за да определим колко добре познаваш България.", settings).ContinueWith((t) =>
            {
                PageButton.IsEnabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
