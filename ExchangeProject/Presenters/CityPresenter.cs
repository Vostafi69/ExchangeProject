using ExchangeProject.Models.Cities;
using ExchangeProject.Presenters.Common;
using ExchangeProject.Repositories._CityRepository;
using ExchangeProject.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExchangeProject.Presenters
{
    public class CityPresenter
    {
        private ICityView view;
        private ICityRepository repository;
        private BindingSource citiesBindingSource;
        private IEnumerable<ICity> cityList;

        public CityPresenter(ICityView view, ICityRepository repository)
        {
            this.citiesBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            this.view.SearchEvent += SearchCity;
            this.view.AddNewEvent += AddNewCity;
            this.view.DeleteEvent += DeleteSelectedCity;
            this.view.UpdateEvent += UpdateSelectedCity;
            this.view.CopyEvent += CopySelectedCity;
            this.view.SetCityListBindingSource(citiesBindingSource);
            LoadAllCityList();
            this.view.Show();
        }

        private void CopySelectedCity(object sender, EventArgs e)
        {
            var city = (ICity)citiesBindingSource.Current;
            view.CityId = city.CityId.ToString();
            view.CityName = city.CityName;
        }

        private void UpdateSelectedCity(object sender, EventArgs e)
        {
            ICity model = new City();
            model.CityId = Convert.ToInt32(view.CityId);
            model.CityName = view.CityName;
            try
            {
                new ModelValidation().Validate(model);
                repository.Update(model);
                view.Message = "Запись о городе обновлена";
                LoadAllCityList();
                ClearViewFields();
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }
        }

        private void AddNewCity(object sender, EventArgs e)
        {
            ICity model = new City();
            model.CityName = view.CityName;
            try
            {
                new ModelValidation().Validate(model);
                repository.Add(model);
                view.Message = "Запись о городе добавлена";
                LoadAllCityList();
                ClearViewFields();
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }
        }

        private void SearchCity(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(this.view.SearchValue);
            if (emptyValue == false)
                cityList = repository.GetByValue(this.view.SearchValue);
            else cityList = repository.GetAll();
            citiesBindingSource.DataSource = cityList;
        }

        private void DeleteSelectedCity(object sender, EventArgs e)
        {
            try
            {
                var city = (ICity)citiesBindingSource.Current;
                repository.Delete(city.CityId);
                view.Message = "Запись о городе удалена";
                LoadAllCityList();
                ClearViewFields();
            }
            catch (Exception ex)
            {
                view.Message = "Ошибка! " + ex.Message;
            }
        }

        private void LoadAllCityList()
        {
            cityList = repository.GetAll();
            citiesBindingSource.DataSource = cityList;
        }

        private void ClearViewFields()
        {
            view.CityId = "0";
            view.CityName = "";
        }
    }
}
