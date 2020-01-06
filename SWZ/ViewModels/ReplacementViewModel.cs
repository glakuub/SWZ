using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWZ.Models;

namespace SWZ.ViewModels
{
    class ReplacementViewModel: NotificationBase<ReplacementModel>
    {
        public ReplacementViewModel(ReplacementModel replacement= null) : base(replacement) { }
       
        public string DateOfAuthorization
        {
            get { return this_.dateOfAuthorization.ToLongDateString(); }
          
        }
        

    }
}
