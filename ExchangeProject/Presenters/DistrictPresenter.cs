using ExchangeProject.Models.Districts;
using ExchangeProject.Presenters.Common;
using ExchangeProject.Repositories._DistrictRepository;
using ExchangeProject.Views.DistrictView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExchangeProject.Presenters
{
    public class DistrictPresenter
    {
        private IDistrictView view;
        private IDistrictRepository repository;
        private BindingSource districtsBindingSource;
        private IEnumerable<IDistrict> districtsList;

        public DistrictPresenter(IDistrictView view, IDistrictRepository repository)
        {
            this.districtsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            this.view.SearchEvent += Search;
            this.view.AddNewEvent += AddNew;
            this.view.DeleteEvent += DeleteSelected;
            this.view.UpdateEvent += UpdateSelected;
            this.view.CopyEvent += CopySelected;
            this.view.SetDistrictListBindingSource(districtsBindingSource);
            LoadAllDataList();
            this.view.Show();
        }

        private void CopySelected(object sender, EventArgs e)
        {
            var district = (IDistrict)districtsBindingSource.Current;
            view.DistrictID = district.DistrictId.ToString();
            view.DistrictName = district.DistrictName;
        }

        private void UpdateSelected(object sender, EventArgs e)
        {
            IDistrict model = new District();
            model.DistrictId = Convert.ToInt32(view.DistrictID);
            model.DistrictName = view.DistrictName;
            try
            {
                new ModelValidation().Validate(model);
                repository.Update(model);
                view.Message = "Запись об улице обновлена";
                LoadAllDataList();
                ClearViewFields();
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }
        }

        private void DeleteSelected(object sender, EventArgs e)
        {
            try
            {
                var district = (IDistrict)districtsBindingSource.Current;
                repository.Delete(district.DistrictId);
                view.Message = "Запись об улице удалена";
                LoadAllDataList();
                ClearViewFields();
            }
            catch (Exception ex)
            {
                view.Message = "Ошибка! " + ex.Message;
            }
        }

        private void AddNew(object sender, EventArgs e)
        {
            IDistrict model = new District();
            model.DistrictName = view.DistrictName;
            try
            {
                new ModelValidation().Validate(model);
                repository.Add(model);
                view.Message = "Запись об улице добавлена";
                LoadAllDataList();
                ClearViewFields();
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }
        }

        private void ClearViewFields()
        {
            view.DistrictID = "0";
            view.DistrictName = "";
        }

        private void Search(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(this.view.SearchValue);
            if (emptyValue == false)
                districtsList = repository.GetByValue(this.view.SearchValue);
            else districtsList = repository.GetAll();
            districtsBindingSource.DataSource = districtsList;
        }

        private void LoadAllDataList()
        {
            districtsList = repository.GetAll();
            districtsBindingSource.DataSource = districtsList;
        }
    }
}
