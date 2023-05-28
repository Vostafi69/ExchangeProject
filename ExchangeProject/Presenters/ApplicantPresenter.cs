using ExchangeProject.Models.Applicant;
using ExchangeProject.Presenters.Common;
using ExchangeProject.Repositories._ApplicantRepository;
using ExchangeProject.Views.ApplicantView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExchangeProject.Presenters
{
    public class ApplicantPresenter
    {
        private IApplicantView view;
        private IApplicantRepository repository;
        private BindingSource applicantsBindingSource;
        private IEnumerable<IApplicant> applicantsList;

        public ApplicantPresenter(IApplicantView view, IApplicantRepository repository)
        {
            this.applicantsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            this.view.SearchEvent += Search;
            this.view.AddNewEvent += AddNew;
            this.view.DeleteEvent += DeleteSelected;
            this.view.UpdateEvent += UpdateSelected;
            this.view.CopyEvent += CopySelected;
            this.view.SetCityListBindingSource(applicantsBindingSource);
            LoadAllApplicantsList();
            this.view.Show();
        }

        private void CopySelected(object sender, EventArgs e)
        {
            var applicant = (IApplicant)applicantsBindingSource.Current;
            view.JoblessId = applicant.JoblessId.ToString();
            view.Lastname = applicant.Lastname;
            view.ApplicantName = applicant.Name;
            view.Passport = applicant.Passport;
            view.PassportDate = applicant.PassportDate.ToString();
            view.PassportRegion = applicant.PassportRegion;
            view.Phone = applicant.Phone;
            view.StudyPlace = applicant.StudyPlace.ToString();
            view.StudyTypeID = applicant.StudyTypeID.ToString();
            view.Surname = applicant.Surname;
            view.Age = applicant.Age.ToString();
            view.CityId = applicant.CityId.ToString();
            view.Deleted = applicant.Deleted.ToString();
            view.DistrictId = applicant.DistrictId.ToString();
        }

        private void UpdateSelected(object sender, EventArgs e)
        {
            IApplicant model = new Applicant();
            model.JoblessId = Convert.ToInt32(view.JoblessId);
            model.Lastname = view.Lastname;
            model.Name = view.ApplicantName;
            model.Passport = view.Passport;
            model.PassportDate = Convert.ToDateTime(view.PassportDate);
            model.PassportRegion = view.PassportRegion;
            model.Phone = view.Phone;
            model.StudyPlace = Convert.ToInt32(view.StudyPlace);
            model.StudyTypeID = Convert.ToInt32(view.StudyTypeID);
            model.Surname = view.Surname;
            model.DistrictId = Convert.ToInt32(view.DistrictId);
            model.Deleted = bool.Parse(view.Deleted);
            model.Age = Convert.ToInt32(view.Age);
            model.CityId = Convert.ToInt32(view.CityId);
            try
            {
                new ModelValidation().Validate(model);
                repository.Update(model);
                view.Message = "Запись о заявители обновлена";
                LoadAllApplicantsList();
                ClearViewFields();
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }
        }

        private void AddNew(object sender, EventArgs e)
        {
            IApplicant model = new Applicant();
            model.Lastname = view.Lastname;
            model.Name = view.ApplicantName;
            model.Passport = view.Passport;
            model.PassportDate = Convert.ToDateTime(view.PassportDate);
            model.PassportRegion = view.PassportRegion;
            model.Phone = view.Phone;
            model.StudyPlace = Convert.ToInt32(view.StudyPlace);
            model.StudyTypeID = Convert.ToInt32(view.StudyTypeID);
            model.Surname = view.Surname;
            model.DistrictId = Convert.ToInt32(view.DistrictId);
            model.Deleted = Convert.ToBoolean(view.Deleted);
            model.Age = Convert.ToInt32(view.Age);
            model.CityId = Convert.ToInt32(view.CityId);
            try
            {
                new ModelValidation().Validate(model);
                repository.Add(model);
                view.Message = "Запись о заявителе добавлена";
                LoadAllApplicantsList();
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
                applicantsList = repository.GetByValue(view.SearchValue);
            else applicantsList = repository.GetAll();
            applicantsBindingSource.DataSource = applicantsList;
        }

        private void DeleteSelected(object sender, EventArgs e)
        {
            try
            {
                var applicant = (IApplicant)applicantsBindingSource.Current;
                repository.Delete(applicant.JoblessId);
                view.Message = "Запись о заявителе удалена";
                LoadAllApplicantsList();
                ClearViewFields();
            }
            catch (Exception ex)
            {
                view.Message = "Ошибка! " + ex.Message;
            }
        }

        private void LoadAllApplicantsList()
        {
            applicantsList = repository.GetAll();
            applicantsBindingSource.DataSource = applicantsList;
        }

        private void ClearViewFields()
        {
            view.JoblessId = "0";
            view.Lastname = "";
            view.ApplicantName = "";
            view.Passport = "";
            view.PassportDate = "";
            view.PassportRegion = "";
            view.Phone = "";
            view.StudyPlace = "";
            view.StudyTypeID = "";
            view.Surname = "";
            view.Age = "";
            view.CityId = "";
            view.Deleted = "false";
            view.DistrictId = "";
        }
    }
}
