using System;
using System.Windows.Forms;

namespace ExchangeProject.Views.DistrictView
{
    public interface IDistrictView
    {
        #region --Events--
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler UpdateEvent;
        event EventHandler CopyEvent;
        #endregion

        #region --Fields--
        string DistrictID { get; set; }
        string DistrictName { get; set; }
        string SearchValue { get; set; }
        string Message { get; set; }
        #endregion

        #region --Methods--
        void SetDistrictListBindingSource(BindingSource districtlist);
        void Show();
        #endregion
    }
}
