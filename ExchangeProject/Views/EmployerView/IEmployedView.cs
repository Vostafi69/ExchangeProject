using System;
using System.Windows.Forms;

namespace ExchangeProject.Views.EmployerView
{
    interface IEmployedView
    {
        #region --Events--
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler UpdateEvent;
        event EventHandler CopyEvent;
        #endregion

        #region --Fields--
        string JobId { get; set; }
        string MemberId { get; set; }
        string SearchValue { get; set; }
        string Message { get; set; }
        #endregion

        #region --Methods--
        void SetListBindingSource(BindingSource empList);
        void Show();
        #endregion
    }
}
