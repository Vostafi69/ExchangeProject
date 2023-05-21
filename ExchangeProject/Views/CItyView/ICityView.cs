using System;
using System.Windows.Forms;

namespace ExchangeProject.Views
{
    public interface ICityView
    {
        #region --Events--
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler UpdateEvent;
        event EventHandler CopyEvent;
        #endregion

        #region --Fields--
        string CityId { get; set; }
        string CityName { get; set; }
        string SearchValue { get; set; }
        string Message { get; set; }
        #endregion

        #region --Methods--
        void SetCityListBindingSource(BindingSource cityList);
        void Show();
        #endregion
    }
}
