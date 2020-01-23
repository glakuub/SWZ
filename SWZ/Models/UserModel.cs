using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWZ.DAL.Users;

namespace SWZ.Models
{
    class UserModel
    {
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string Login { set; get; }
        public string LastName { set; get; }
        public string Password { set; get; }

        public static UserModel GetById(int id)
        {
            UserModel userModel = null;
            var userDao = new MSSQLUserDAO();
            var userDb = userDao.GetUserById(id);
            if(userDb!=null)
            {
                userModel = new UserModel();
                userModel.Id = userDb.Id;
                userModel.FirstName = userDb.FirstName;
                userModel.LastName = userDb.LastName;
                userModel.Login = userDb.Login;
                userModel.Password = userDb.Password;

            }

            return userModel;


        }
    }
    
}
