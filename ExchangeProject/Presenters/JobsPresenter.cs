using ExchangeProject.Models.Job;
using ExchangeProject.Presenters.Common;
using ExchangeProject.Repositories._JobsRepository;
using ExchangeProject.Views.JobView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExchangeProject.Presenters
{
    class JobsPresenter
    {
        private IJobView view;
        private IJobsRepository repository;
        private BindingSource jobsBindingSource;
        private IEnumerable<IJob> jobsList;

        public JobsPresenter(IJobView view, IJobsRepository repository)
        {
            this.jobsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            this.view.SearchEvent += Search;
            this.view.AddNewEvent += AddNew;
            this.view.DeleteEvent += DeleteSelected;
            this.view.UpdateEvent += UpdateSelected;
            this.view.CopyEvent += CopySelected;
            this.view.SetListBindingSource(jobsBindingSource);
            LoadAllDataList();
            this.view.Show();
        }

        private void CopySelected(object sender, EventArgs e)
        {
            var job = (IJob)jobsBindingSource.Current;
            view.JobId = job.JobId.ToString();
            view.JobGiverId = job.JobGiverId.ToString();
            view.JobName = job.JobName.ToString();
            view.Money = job.Money.ToString();
            view.More = job.More.ToString();
            view.Available = job.Available.ToString();
            view.JobType = job.JobType.ToString();
        }

        private void UpdateSelected(object sender, EventArgs e)
        {
            IJob model = new Job();
            model.JobId = Convert.ToInt32(view.JobId);
            model.JobGiverId = Convert.ToInt32(view.JobGiverId);
            model.JobName = view.JobName;
            model.Money = Convert.ToDecimal(view.Money);
            model.More = view.More;
            model.Available = Convert.ToBoolean(view.Available);
            model.JobType = view.JobType;
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
                var job = (IJob)jobsBindingSource.Current;
                repository.Delete(job.JobId);
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
            IJob model = new Job();
            model.JobId = Convert.ToInt32(view.JobId);
            model.JobGiverId = Convert.ToInt32(view.JobGiverId);
            model.JobName = view.JobName;
            model.Money = Convert.ToDecimal(view.Money);
            model.More = view.More;
            model.Available = Convert.ToBoolean(view.Available);
            model.JobType = view.JobType;
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
            view.JobId = "0";
            view.JobGiverId = "";
            view.JobName = "";
            view.Money = "";
            view.More = "";
            view.Available = "false";
            view.JobType = "";
        }

        private void Search(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(this.view.SearchValue);
            if (emptyValue == false)
                jobsList = repository.GetByValue(this.view.SearchValue);
            else jobsList = repository.GetAll();
            jobsBindingSource.DataSource = jobsList;
        }

        private void LoadAllDataList()
        {
            jobsList = repository.GetAll();
            jobsBindingSource.DataSource = jobsList;
        }
    }
}
