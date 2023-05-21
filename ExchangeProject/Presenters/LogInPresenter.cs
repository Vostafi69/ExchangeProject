using ExchangeProject.Models.UserDTO;
using ExchangeProject.Repositories._LogInRepository;
using ExchangeProject.Views.LogInView;
using ExchangeProject.Views.MainView;
using System;
using System.Windows.Forms;

namespace ExchangeProject.Presenters
{
    class LogInPresenter
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
                new MainPresenter(mainView, userDto.NpgsqlConnectionString);
            }
            catch
            {
                view.Message = "Неверный логин или пароль";
                MessageBox.Show(view.Message);
            }
        }
    }
}
