using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Users
{
    class User
    {
        public enum UserType { EMPLOYEE , STUDENT }

        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
        public string FieldOfStudy { set; get; }
        public string FacultySymbol { set; get; }
        public string Type { set; get; }


    }
}
