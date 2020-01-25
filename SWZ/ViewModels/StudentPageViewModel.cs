using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SWZ.Models;

namespace SWZ.ViewModels
{
    class StudentPageViewModel
    {
       
        public ICommand GoBack { set; get; }
        public ICommand GoToFindReplacement { set; get; }
        public ICommand GoToCreaeteProposition { set; get; }

        public string LoggedUserName
        {
            get
            {
                return UserSession.Get.IsSet ? $"Zalogowano jako: { UserSession.Get.StudentFirstName} {UserSession.Get.StudentLastName}" : string.Empty;
            }
        }

        public StudentPageViewModel()
        {   
            
            
        }

        private string GetUserName(int id)
        {
            StudentViewModel user = null;
            try
            {
                var sm = StudentModel.GetById(id);
                user = new StudentViewModel(sm);
            }
            catch(DataServiceException e)
            {
                Debug.WriteLine(e.Message);
               
            }
            return user==null?"Błąd połącznia":$"{user.FirstName} {user.LastName}";
        }
    }
    class LoginException : Exception
    {
        private static readonly string _message = "Could not log in user ";
        public override string Message => _message;
    }
}
