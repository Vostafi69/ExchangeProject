using System;
using System.Windows.Forms;

namespace ExchangeProject.Views.RegistrationView
{
    public interface IRegistrationView
    {
        #region --Events--
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler UpdateEvent;
        event EventHandler CopyEvent;
        #endregion

        #region --Fields--
        string MemberId { get; set; }
        string JoblessId { get; set; }
        string Registrar { get; set; }
        string RegDate { get; set; }
        string Payment { get; set; }
        string Experience { get; set; }
        string Comment { get; set; }
        string SearchValue { get; set; }
        string Message { get; set; }
        #endregion

        #region --Methods--
        void SetListBindingSource(BindingSource regList);
        void Show();
        #endregion
    }
}
