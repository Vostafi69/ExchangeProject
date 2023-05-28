using System;
using System.Windows.Forms;

namespace ExchangeProject.Views.JobGiversView
{
    public interface IJobGiversView
    {
        #region --Events--
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler UpdateEvent;
        event EventHandler CopyEvent;
        #endregion

        #region --Fields--
        string JobGiverId { get; set; }
        string JobGiver { get; set; }
        string CityId { get; set; }
        string DistrictId { get; set; }
        string Mobile { get; set; }
        string SearchValue { get; set; }
        string Message { get; set; }
        #endregion

        #region --Methods--
        void SetListBindingSource(BindingSource jobGiversList);
        void Show();
        #endregion
    }
}
