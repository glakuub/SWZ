using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.ViewModels
{
    



        public sealed class UserSession
        {
            private static UserSession _current = new UserSession();




            private UserSession() {
                UserID = null;
            }

            public static UserSession Get { get { return _current; } }

            public int? UserID { set; get; }
            



        }
    


}
