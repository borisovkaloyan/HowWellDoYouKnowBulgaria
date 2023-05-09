using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pmu_Course_Work
{
    public partial class App : Application
    {
        public App()
        {
            InitApp();

            InitializeComponent();

            MainPage = new MainPage();    
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private async void InitApp()
        {
            Globals.questions.Add(new Question("Колко километра е най-дългата българска река?",
                                  new List<string>() { "368 километра", "168 километра", "298 километра", "490 километра" }));

            Globals.questions.Add(new Question("Как се нарича първата българска конституция?",
                                  new List<string>() { "Търновска", "Стамболовска", "Софийска", "Стефанова" }));

            Globals.questions.Add(new Question("Какви са първите букви на регистрационен номер на кола от Силистра?",
                                  new List<string>() { "СС", "С", "СР", "СТ" }));

            Globals.questions.Add(new Question("Какво е истинското име на Майстора?",
                                  new List<string>() { "Владимир Димитров", "Колю Фичето", "Иван Вазов", "Пейо Яворов" }));

            Globals.questions.Add(new Question("Какво е името на българската песен в космоса?",
                                  new List<string>() { "Излел е Дельо хайдутин", "Палатка", "Хаджи Димитър", "Хубава си, моя горо" }));

            Globals.questions.Add(new Question("Кое от изброените е основна съставка на лютеницата?",
                                  new List<string>() { "Чушки", "Картофи", "Чесън", "Авокадо" }));

            Globals.questions.Add(new Question("Кой е българският изпълнител, познат с това, че се поти много?",
                                  new List<string>() { "Веселин Маринов", "Фики", "Азис", "Лили Иванова" }));

            Globals.questions.Add(new Question("Коя дума е написана правилно?",
                                  new List<string>() { "Овца", "Увца", "Офца", "Овса" }));

            Globals.questions.Add(new Question("Кой е авторът на Хаджи Димитър?",
                                  new List<string>() { "Христо Ботев", "Иван Вазов", "Димитър Христов", "Пейо Яворов" }));

            Globals.questions.Add(new Question("Как наричаме кратка история с поука?",
                                  new List<string>() { "Басня", "Роман", "Историйка", "Повест" }));

            Globals.questions.Add(new Question("Какво означава думата 'буа', идваща от трънски диалект?",
                                  new List<string>() { "Бълха", "Бия", "Боя", "Блъска" }));

            Globals.questions.Add(new Question("С какви растения е най-известен Казанлък?",
                                  new List<string>() { "Рози", "Лозя", "Банани", "Чубрица" }));

            Globals.questions.Add(new Question("Коя е най-дългата пещера в България?",
                                  new List<string>() { "Духлата", "Дяволското гърло", "Съева дупка", "Леденика" }));

            Globals.questions.Add(new Question("Кое от тези НЕ е областен град?",
                                  new List<string>() { "Сандански", "Перник", "Кюстендил", "Търговище" }));

            var locales = await TextToSpeech.GetLocalesAsync();

            Globals.locale = locales.FirstOrDefault();

            foreach (var locale in locales)
            {
                if (locale.Country == "BG")
                {
                    if (locale.Language == "bg")
                    {
                        Globals.locale = locale;
                        break;
                    }
                }
            }
        }
    }
}
