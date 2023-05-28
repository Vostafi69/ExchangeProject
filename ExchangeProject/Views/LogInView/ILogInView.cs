using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeProject.Views.LogInView
{
    public interface ILogInView
    {
        #region --Events--
        event EventHandler EventLogIn;
        #endregion

        #region --Fields--
        string UserLogin { get; set; }
        string UserPassword { get; set; }
        string Message { get; set; }
        #endregion
        #region --Methods--
        void Hide();
        void Show();
        #endregion
    }
}
