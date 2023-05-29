using ExchangeProject.Models.UserDTO;
using ExchangeProject.Repositories._LogInRepository;
using ExchangeProject.Views.LogInView;
using ExchangeProject.Views.MainView;
using Npgsql;
using System;
using System.Windows.Forms;

namespace ExchangeProject.Presenters
{
    public class LogInPresenter
    {
        private ILogInView view;
        private ILogInRepository repository;
        private IUser userDto;

        public LogInPresenter(ILogInView view, ILogInRepository repository)
        {
            this.view = view;
            this.repository = repository;
            this.view.EventLogIn += LogInUser;
        }

        private void LogInUser(object sender, EventArgs e)
        {
            IMainView mainView = new MainView();
            try
            {
                userDto = repository.GetRole(view.UserLogin, view.UserPassword);
                this.view.Hide();
                new MainPresenter(mainView, userDto, this.view);
            }
            catch (Exception ex)
            {
                string answer = ex.ToString();
                if (answer.Contains("3D000")) view.Message = "Не удалось подключиться к базе данных";
                else view.Message = "Неверный логин или пароль";
                MessageBox.Show(view.Message);
            }
        }
    }
}
