using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pmu_Course_Work
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuestionPage : ContentPage
	{
        private Label QuestionID;
        private Label QuestionText;
        private Question question;

        private Button Answer1;
        private Button Answer2;
        private Button Answer3;
        private Button Answer4;

        public bool ButtonsEnabled = false;

        public QuestionPage ()
		{
            InitializeComponent();

            question = Globals.questions[Globals.questionId];

            QuestionID = (Label)this.FindByName("QLabel");
            QuestionID.Text = "Въпрос " + ((Globals.questionId + 1).ToString());

            QuestionText = (Label)this.FindByName("QText");
            QuestionText.Text = question.question;

            Answer1 = (Button)this.FindByName("Ans1");
            Answer2 = (Button)this.FindByName("Ans2");
            Answer3 = (Button)this.FindByName("Ans3");
            Answer4 = (Button)this.FindByName("Ans4");

            ExplainQuestion(question);

            ExplainButton(Answer1, question.answer[0]);
            ExplainButton(Answer2, question.answer[1]);
            ExplainButton(Answer3, question.answer[2]);
            ExplainButton(Answer4, question.answer[3]);
        }

        private async void ExplainQuestion(Question question)
        {
            var locales = await TextToSpeech.GetLocalesAsync();

            var locale = locales.FirstOrDefault();

            var settings = new SpeechOptions()
            {
                Locale = locale
            };

            await TextToSpeech.SpeakAsync(question.question, settings).ContinueWith((t) =>
            {
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async void ExplainButton(Button button, string text)
        {
            var locales = await TextToSpeech.GetLocalesAsync();

            var locale = locales.FirstOrDefault();

            var settings = new SpeechOptions()
            {
                Locale = locale
            };

            await TextToSpeech.SpeakAsync(text, settings).ContinueWith((t) =>
            {
                button.Text = text;
                if (button.ClassId == "Ans4")
                {
                    ActivateButtons();
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void ActivateButtons()
        {
            Answer1.IsEnabled = true;
            Answer2.IsEnabled = true;
            Answer3.IsEnabled = true;
            Answer4.IsEnabled = true;
        }

        private void VerifyAnswer(object sender, EventArgs args)
		{
            if(sender is Button)
            {
                Button button = (Button)sender;

                if(button.Text == question.correctAnswer)
                {
                    Globals.correctAnswers += 1;
                }

                Globals.questionId += 1;

                if ((Globals.questionId < 15) && (Globals.questionId < Globals.questions.Count))
                {
                    QuestionPage questionPage = new QuestionPage();                    

                    Navigation.PushModalAsync(questionPage);
                }
                else
                {
                    EndPage endPage = new EndPage();

                    Navigation.PushModalAsync(endPage);
                }
            }
		}
    }
}