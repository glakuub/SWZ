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

        public string LoggedUserName {
            get {
                return UserSession.Get.UserID==null?string.Empty: $"Zalogowano jako: {GetUserName(UserSession.Get.UserID.Value)}"; } }

        public StudentPageViewModel()
        {
            UserSession.Get.UserID = 2;
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
        private static readonly string _message = "Could not connect to data source. ";
        public override string Message => base.Message;
    }
}
