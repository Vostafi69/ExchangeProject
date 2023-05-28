using System;
using System.Windows.Forms;

namespace ExchangeProject.Views.JobView
{
    public interface IJobView
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
        string JobGiverId { get; set; }
        string JobName { get; set; }
        string Money { get; set; }
        string More { get; set; }
        string Available { get; set; }
        string JobType { get; set; }
        string SearchValue { get; set; }
        string Message { get; set; }
        #endregion

        #region --Methods--
        void SetListBindingSource(BindingSource jobsList);
        void Show();
        #endregion
    }
}
