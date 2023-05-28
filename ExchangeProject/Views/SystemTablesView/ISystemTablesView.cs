using System.Collections.Generic;
using System.Windows.Forms;

namespace ExchangeProject.Views.SystemTablesView
{
    public interface ISystemTablesView
    {
        #region --Methods--
        void SetSystemListBindingSource(List<BindingSource> systemList);
        void Show();
        #endregion
    }
}
