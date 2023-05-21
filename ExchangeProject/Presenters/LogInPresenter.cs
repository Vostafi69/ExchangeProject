using ExchangeProject.Models.UserDTO;
using ExchangeProject.Repositories._LogInRepository;
using ExchangeProject.Views.LogInView;
using ExchangeProject.Views.MainView;
using System;

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
            userDto = repository.GetRole(view.UserLogin, view.UserPassword);
            this.view.Hide();
            new MainPresenter(mainView, userDto.NpgsqlConnectionString);
        }
    }
}
