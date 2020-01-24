using System;
using System.Collections.Generic;
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
            var user = new StudentViewModel(StudentModel.GetById(id));
            return $"{user.FirstName} {user.LastName}";
        }
    }
}
