using ExchangeProject.Models.StudyPlaces;
using ExchangeProject.Presenters.Common;
using ExchangeProject.Repositories._StudyPlaceRepository;
using ExchangeProject.Views.StudyPlaceView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExchangeProject.Presenters
{
    public class StudyPlacePresenter
    {
        private IStudyPlaceView view;
        private IStudyPlaceRepository repository;
        private BindingSource studyPlacesBindingSource;
        private IEnumerable<IStudyPlaces> studyPlacesList;

        public StudyPlacePresenter(IStudyPlaceView view, IStudyPlaceRepository repository)
        {
            studyPlacesBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            this.view.CopyEvent += CopySelected;
            this.view.SearchEvent += Search;
            this.view.AddNewEvent += AddNew;
            this.view.DeleteEvent += DeleteSelected;
            this.view.UpdateEvent += UpdateSelected;
            this.view.SetStudyPlaceListBindingSource(studyPlacesBindingSource);
            LoadAllStudyPlacesList();
            this.view.Show();
        }

        private void UpdateSelected(object sender, EventArgs e)
        {
            IStudyPlaces model = new StudyPlaces();
            model.studyid = Convert.ToInt32(view.StudyId);
            model.studyplace = view.StudyPlace;
            model.cityid = Convert.ToInt32(view.CityId);
            model.districtid = Convert.ToInt32(view.DistrictId);
            try
            {
                new ModelValidation().Validate(model);
                repository.Update(model);
                view.Message = "Запись о месте обучения обновлена";
                LoadAllStudyPlacesList();
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
                var studyplace = (IStudyPlaces)studyPlacesBindingSource.Current;
                repository.Delete(studyplace.studyid);
                view.Message = "Запись о месте обучения удалена";
                LoadAllStudyPlacesList();
                ClearViewFields();
            }
            catch (Exception ex)
            {
                view.Message = "Ошибка! " + ex.Message;
            }
        }

        private void AddNew(object sender, EventArgs e)
        {
            IStudyPlaces model = new StudyPlaces();
            model.studyplace = view.StudyPlace;
            model.cityid = Convert.ToInt32(view.StudyId);
            model.districtid = Convert.ToInt32(view.DistrictId);
            try
            {
                new ModelValidation().Validate(model);
                repository.Add(model);
                view.Message = "Запись о месте обучения добавлена";
                LoadAllStudyPlacesList();
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
                studyPlacesList = repository.GetByValue(view.SearchValue);
            else studyPlacesList = repository.GetAll();
            studyPlacesBindingSource.DataSource = studyPlacesList;
        }

        private void CopySelected(object sender, EventArgs e)
        {
            var studyPlace = (IStudyPlaces)studyPlacesBindingSource.Current;
            view.StudyId = studyPlace.studyid.ToString();
            view.StudyPlace = studyPlace.studyplace;
            view.DistrictId = studyPlace.districtid.ToString();
            view.CityId = studyPlace.cityid.ToString();
        }

        private void LoadAllStudyPlacesList()
        {
            studyPlacesList = repository.GetAll();
            studyPlacesBindingSource.DataSource = studyPlacesList;
        }

        private void ClearViewFields()
        {
            view.StudyId = "0";
            view.StudyPlace = "";
            view.CityId = "";
            view.DistrictId = "";
        }
    }
}
