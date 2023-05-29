using ExchangeProject.Models.Employed;
using ExchangeProject.Presenters.Common;
using ExchangeProject.Repositories._EmployedRepository;
using ExchangeProject.Views.EmployerView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExchangeProject.Presenters
{
    public class EmployedPresenter
    {
        private IEmployedView view;
        private IEmployedRepository repository;
        private BindingSource employedBindingSource;
        private IEnumerable<IEmployed> employerList;

        public EmployedPresenter(IEmployedView view, IEmployedRepository repository)
        {
            this.employedBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            this.view.SearchEvent += Search;
            this.view.AddNewEvent += AddNew;
            this.view.DeleteEvent += DeleteSelected;
            this.view.UpdateEvent += UpdateSelected;
            this.view.CopyEvent += CopySelected;
            this.view.SetListBindingSource(employedBindingSource);
            LoadAllDataList();
            this.view.Show();
        }

        private void CopySelected(object sender, EventArgs e)
        {
            var employed = (IEmployed)employedBindingSource.Current;
            view.JobId = employed.JobId.ToString();
            view.MemberId = employed.MemberId.ToString();
        }

        private void UpdateSelected(object sender, EventArgs e)
        {
            IEmployed model = new Employed();
            model.JobId = Convert.ToInt32(view.JobId);
            model.MemberId = Convert.ToInt32(view.MemberId);
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
                var employed = (IEmployed)employedBindingSource.Current;
                repository.Delete(employed.MemberId);
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
            IEmployed model = new Employed();
            model.MemberId = Convert.ToInt32(view.MemberId);
            model.JobId = Convert.ToInt32(view.JobId);
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
            view.JobId = "";
            view.MemberId = "";
        }

        private void Search(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(this.view.SearchValue);
            if (emptyValue == false)
                employerList = repository.GetByValue(this.view.SearchValue);
            else employerList = repository.GetAll();
            employedBindingSource.DataSource = employerList;
        }

        private void LoadAllDataList()
        {
            employerList = repository.GetAll();
            employedBindingSource.DataSource = employerList;
        }
    }
}
