using System;
using System.Windows.Forms;

namespace ExchangeProject.Views
{
    public interface ICityView
    {
        #region --Fields--
        string CityId { get; set; }
        string CityName { get; set; }
        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        #endregion

        #region --Events--
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;
        #endregion

        #region --Methods--
        void SetCityListBindingSource(BindingSource cityList);
        void Show();
        #endregion
    }
}
