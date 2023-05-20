using ExchangeProject.Models.Cities;
using ExchangeProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeProject.Presenters
{
    public class CityPresenter
    {
        private ICityView view;
        private ICityRepository repository;
        private BindingSource citiesBindingSource;
        private IEnumerable<City> cityList;

        public CityPresenter(ICityView view, ICityRepository repository)
        {
            this.citiesBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            this.view.SearchEvent += SearchCity;
            this.view.AddNewEvent += AddNewCity;
            this.view.DeleteEvent += LoadSelectedCityToEdit;
            this.view.SaveEvent += SaveCity;
            this.view.CancelEvent += CancelAction;
            this.view.SetCityListBindingSource(citiesBindingSource);
            LoadAllCityList();
            this.view.Show();
        }

        private void LoadAllCityList()
        {
            cityList = repository.GetAll();
            citiesBindingSource.DataSource = cityList;
        }

        private void CancelAction(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveCity(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadSelectedCityToEdit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddNewCity(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SearchCity(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(this.view.SearchValue);
            if (emptyValue == false)
                cityList = repository.GetByValue(this.view.SearchValue);
            else cityList = repository.GetAll();
            citiesBindingSource.DataSource = cityList;
        }
    }
}
