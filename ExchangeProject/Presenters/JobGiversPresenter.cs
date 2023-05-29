using ExchangeProject.Models.JobGivers;
using ExchangeProject.Presenters.Common;
using ExchangeProject.Repositories._JobGiversRepository;
using ExchangeProject.Views.JobGiversView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExchangeProject.Presenters
{
    public class JobGiversPresenter
    {
        private IJobGiversView view;
        private IJobGiversRepository repository;
        private BindingSource jobGiversBindingSource;
        private IEnumerable<IJobGivers> jobGiversList;

        public JobGiversPresenter(IJobGiversView view, IJobGiversRepository repository)
        {
            this.jobGiversBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            this.view.SearchEvent += Search;
            this.view.AddNewEvent += AddNew;
            this.view.DeleteEvent += DeleteSelected;
            this.view.UpdateEvent += UpdateSelected;
            this.view.CopyEvent += CopySelected;
            this.view.SetListBindingSource(jobGiversBindingSource);
            LoadAllDataList();
            this.view.Show();
        }

        private void CopySelected(object sender, EventArgs e)
        {
            var jobgiver = (IJobGivers)jobGiversBindingSource.Current;
            view.JobGiverId = jobgiver.JobGiverId.ToString();
            view.JobGiver = jobgiver.JobGiver.ToString();
            view.CityId = jobgiver.CityId.ToString();
            view.DistrictId = jobgiver.DistrictId.ToString();
            view.Mobile = jobgiver.Mobile.ToString();
        }

        private void UpdateSelected(object sender, EventArgs e)
        {
            IJobGivers model = new JobGivers();
            model.JobGiverId = Convert.ToInt32(view.JobGiverId);
            model.JobGiver = view.JobGiver;
            model.CityId = Convert.ToInt32(view.CityId);
            model.DistrictId = Convert.ToInt32(view.DistrictId);
            model.Mobile = view.Mobile;
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
                var district = (IJobGivers)jobGiversBindingSource.Current;
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
            IJobGivers model = new JobGivers();
            model.JobGiverId = Convert.ToInt32(view.JobGiverId);
            model.JobGiver = view.JobGiver;
            model.CityId = Convert.ToInt32(view.CityId);
            model.DistrictId = Convert.ToInt32(view.DistrictId);
            model.Mobile = view.Mobile;
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
            view.JobGiverId = "0";
            view.JobGiver = "";
            view.CityId = "";
            view.DistrictId = "";
            view.Mobile = "";
        }

        private void Search(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(this.view.SearchValue);
            if (emptyValue == false)
                jobGiversList = repository.GetByValue(this.view.SearchValue);
            else jobGiversList = repository.GetAll();
            jobGiversBindingSource.DataSource = jobGiversList;
        }

        private void LoadAllDataList()
        {
            jobGiversList = repository.GetAll();
            jobGiversBindingSource.DataSource = jobGiversList;
        }
    }
}
