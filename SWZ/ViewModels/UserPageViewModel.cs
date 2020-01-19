using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWZ.ViewModels
{
    class UserPageViewModel
    {
        public ICommand GoBack { set; get; }

        public ICommand GoToFindReplacements { set; get; }

        public UserPageViewModel()
        {
            UserSession.Get.UserID = null;
        }
    }
}
