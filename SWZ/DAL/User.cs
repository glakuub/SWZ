﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL
{
    class User
    {
        int id;
        string firstName;
        string lastName;
        string login;
        string password;
        string fieldOfStudy;
        string facultySymbol;
        
        public User(int id)
        {
            this.id = id;
        }
    }
}
