using System;
using System.Windows.Forms;

namespace ExchangeProject.Views.StudyTypeView
{
    public interface IStudyTypeView
    {
        #region --Events--
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler UpdateEvent;
        event EventHandler CopyEvent;
        #endregion

        #region --Fields--
        string StudyTypeID { get; set; }
        string StudyTypeName { get; set; }
        string SearchValue { get; set; }
        string Message { get; set; }
        #endregion

        #region --Methods--
        void SetStudyTypeListBindingSource(BindingSource studytypelist);
        void Show();
        #endregion
    }
}
