using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL
{
    interface IUserDAO
    {
        int insertUser(User user);
        User getUser(int id);
    }

}
