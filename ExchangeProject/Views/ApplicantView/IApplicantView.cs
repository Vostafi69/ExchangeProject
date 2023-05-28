using System;
using System.Windows.Forms;

namespace ExchangeProject.Views.ApplicantView
{
    public interface IApplicantView
    {
        #region --Events--
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler UpdateEvent;
        event EventHandler CopyEvent;
        #endregion

        #region --Fields--
        string JoblessId { get; set; }
        string ApplicantName { get; set; }
        string Lastname { get; set; }
        string Surname { get; set; }
        string StudyTypeID { get; set; }
        string CityId { get; set; }
        string DistrictId { get; set; }
        string StudyPlace { get; set; }
        string Age { get; set; }
        string Passport { get; set; }
        string PassportDate { get; set; }
        string PassportRegion { get; set; }
        string Phone { get; set; }
        string Deleted { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }
        #endregion

        #region --Methods--
        void SetCityListBindingSource(BindingSource applicantsList);
        void Show();
        #endregion
    }
}
