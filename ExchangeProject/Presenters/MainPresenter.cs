using ExchangeProject.Repositories._CityRepository;
using ExchangeProject.Views;
using ExchangeProject.Views.CItyView;
using ExchangeProject.Views.MainView;
using System;

namespace ExchangeProject.Presenters
{
    class MainPresenter
    {
        private IMainView mainView;
        private readonly string npgsqlConnectionString;

        public MainPresenter(IMainView mainView, string npgsqlConnectionString)
        {
            this.mainView = mainView;
            this.npgsqlConnectionString = npgsqlConnectionString;
            this.mainView.ShowCityView += ShowCityView;
            this.mainView.Show();
        }

        private void ShowCityView(object sender, EventArgs e)
        {
            ICityView view = CityView.GetInstance((MainView)mainView);
            ICityRepository repository = new CityRepository(npgsqlConnectionString);
            new CityPresenter(view, repository);
        }
    }
}
