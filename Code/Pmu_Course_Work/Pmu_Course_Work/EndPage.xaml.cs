using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Pmu_Course_Work
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EndPage : ContentPage
    {
        private string Rating = "yeet";
        public EndPage()
        {
            InitializeComponent();
            RateMe();

            ExplainRating();
        }

        private void RateMe()
        {
            switch(Globals.correctAnswers)
            {
                case 0:
                    Rating = "Незадоволителен";
                    break;
                case 1:
                case 2:
                    Rating = "Слаб";
                    break;
                case 3:
                case 4:
                    Rating = "Среден";
                    break;
                case 5:
                case 6:
                    Rating = "Добър";
                    break;
                case 7:
                case 8:
                    Rating = "Много добър";
                    break;
                case 9:
                case 10:
                    Rating = "Отличен";
                    break;
                default:
                    Rating = "Неизвестен";
                    break;
            }

            Ranking.Text += Rating;
            Points.Text += Globals.correctAnswers.ToString();
        }

        private async Task ShareResults()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = "Хей, аз получих ранг " + Rating +
                "! Изкарах " + Globals.correctAnswers.ToString() + " точки. Смяташ ли, че можеш да ме победиш?",
                Uri = "www.google.com",
                Title = "Споделяне на резултат"
            });

        }

        public async void ExplainRating()
        {
            var settings = new SpeechOptions()
            {
                Locale = Globals.locale
            };

            await TextToSpeech.SpeakAsync(Congrats.Text, settings).ContinueWith((t) =>
            {
            }, TaskScheduler.FromCurrentSynchronizationContext());

            await TextToSpeech.SpeakAsync(Ranking.Text, settings).ContinueWith((t) =>
            {
            }, TaskScheduler.FromCurrentSynchronizationContext());

            await TextToSpeech.SpeakAsync(Points.Text, settings).ContinueWith((t) =>
            {
                ActivateButtons();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void ActivateButtons()
        {
            ShareBtn.IsEnabled = true;
            NewTryBtn.IsEnabled = true;
        }

        private void NewAttempt(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();

            Navigation.PushModalAsync(mainPage);
        }

        private void ShareResultsBtn(object sender, EventArgs e)
        {
            _ = ShareResults();
        }
    }
}