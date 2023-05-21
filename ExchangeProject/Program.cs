using ExchangeProject.Presenters;
using ExchangeProject.Repositories._LogInRepository;
using ExchangeProject.Views.LogInView;
using ExchangeProject.Views.MainView;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace ExchangeProject
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ILogInRepository repository = new LogInRepository();
            ILogInView LogInView = new LogInView();
            new LogInPresenter(LogInView, repository);
            Application.Run((Form)LogInView);
        }
    }
}
