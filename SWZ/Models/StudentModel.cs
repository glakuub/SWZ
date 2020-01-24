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

        public string FieldOfStudy { set; get; }
        public string FacultySymbol { set; get; }
        public int IndexNumber { set; get; }

        public new static StudentModel GetById(int id)
        {
            StudentModel studentModel = null;
            var userDao = new MSSQLUserDAO();
            var userDb = userDao.GetUserById(id);
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
                    studentModel.FieldOfStudy = userDb.FieldOfStudy;
                    studentModel.FacultySymbol = userDb.FacultySymbol;
                    studentModel.IndexNumber = userDb.IndexNumber;
                }


            }

            return studentModel;
        }
    }
}
