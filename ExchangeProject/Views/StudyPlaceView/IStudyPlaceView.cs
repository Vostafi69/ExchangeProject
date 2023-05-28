using System;
using System.Windows.Forms;

namespace ExchangeProject.Views.StudyPlaceView
{
    public interface IStudyPlaceView
    {
        #region --Events--
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler UpdateEvent;
        event EventHandler CopyEvent;
        #endregion

        #region --Fields--
        string StudyId { get; set; }
        string StudyPlace { get; set; }
        string CityId { get; set; }
        string DistrictId { get; set; }
        string SearchValue { get; set; }
        string Message { get; set; }
        #endregion

        #region --Methods--
        void SetStudyPlaceListBindingSource(BindingSource styduPlacesList);
        void Show();
        #endregion
    }
}
