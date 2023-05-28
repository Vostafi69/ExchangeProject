using ExchangeProject.Models.StudyTypes;
using ExchangeProject.Presenters.Common;
using ExchangeProject.Repositories._StudyTypeRepository;
using ExchangeProject.Views.StudyTypeView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExchangeProject.Presenters
{
    public class StudyTypePresenter
    {
        private IStudyTypeView view;
        private IStudyTypeRepository repository;
        private BindingSource studyTypeBindingSource;
        private IEnumerable<IStudyType> studyTypesList;

        public StudyTypePresenter(IStudyTypeView view, IStudyTypeRepository repository)
        {
            studyTypeBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            this.view.CopyEvent += CopySelected;
            this.view.SearchEvent += Search;
            this.view.AddNewEvent += AddNew;
            this.view.DeleteEvent += DeleteSelected;
            this.view.UpdateEvent += UpdateSelected;
            this.view.SetStudyTypeListBindingSource(studyTypeBindingSource);
            LoadAllStudyTypesList();
            this.view.Show();
        }

        private void UpdateSelected(object sender, EventArgs e)
        {
            IStudyType model = new StudyType();
            model.StudyTypeId = Convert.ToInt32(view.StudyTypeID);
            model.StudyTypeName = view.StudyTypeName;
            try
            {
                new ModelValidation().Validate(model);
                repository.Update(model);
                view.Message = "Запись о типе образования обновлена";
                LoadAllStudyTypesList();
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
                var studytype = (IStudyType)studyTypeBindingSource.Current;
                repository.Delete(studytype.StudyTypeId);
                view.Message = "Запись о типе образования удалена";
                LoadAllStudyTypesList();
                ClearViewFields();
            }
            catch (Exception ex)
            {
                view.Message = "Ошибка! " + ex.Message;
            }
        }

        private void AddNew(object sender, EventArgs e)
        {
            IStudyType model = new StudyType();
            model.StudyTypeId = Convert.ToInt32(view.StudyTypeID);
            model.StudyTypeName = view.StudyTypeName;
            try
            {
                new ModelValidation().Validate(model);
                repository.Add(model);
                view.Message = "Запись о типе образования добавлена";
                LoadAllStudyTypesList();
                ClearViewFields();
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }
        }

        private void Search(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(view.SearchValue);
            if (emptyValue == false)
                studyTypesList = repository.GetByValue(view.SearchValue);
            else studyTypesList = repository.GetAll();
            studyTypeBindingSource.DataSource = studyTypesList;
        }

        private void CopySelected(object sender, EventArgs e)
        {
            var studyType = (IStudyType)studyTypeBindingSource.Current;
            view.StudyTypeID = studyType.StudyTypeId.ToString();
            view.StudyTypeName = studyType.StudyTypeName;

        }

        private void LoadAllStudyTypesList()
        {
            studyTypesList = repository.GetAll();
            studyTypeBindingSource.DataSource = studyTypesList;
        }

        private void ClearViewFields()
        {
            view.StudyTypeID = "0";
            view.StudyTypeName = "";
        }
    }
}
