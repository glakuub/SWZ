using SWZ.DAL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.Models
{
    class StudentModel: UserModel
    {

        public string fieldOfStudy { set; get; }
        public string facultySymbol { set; get; }

        public new static StudentModel GetById(int id)
        {
            StudentModel studentModel = null;
            var userDao = new MSSQLUserDAO();
            var userDb = userDao.getUser(id);
            if (userDb != null)
            {
                if (Enum.Parse<User.UserType>(userDb.Type.ToUpper()).Equals(User.UserType.STUDENT))
                {
                    studentModel = new StudentModel();
                    studentModel.Id = userDb.Id;
                    studentModel.FirstName = userDb.FirstName;
                    studentModel.LastName = userDb.LastName;
                    studentModel.Login = userDb.Login;
                    studentModel.Password = userDb.Password;
                    studentModel.fieldOfStudy = userDb.FieldOfStudy;
                    studentModel.facultySymbol = userDb.FacultySymbol;
                }


            }

            return studentModel;
        }
    }
}
