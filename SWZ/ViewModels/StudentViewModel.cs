using SWZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.ViewModels
{
    class StudentViewModel:NotificationBase<StudentModel>
    {   
        public int IndexNumber { set { this_.IndexNumber = value; } get { return this_.IndexNumber; } }
        public string FirstName { set { this_.FirstName = value; } get {return this_.FirstName; } }
        public string LastName { set { this_.LastName = value; } get {return this_.LastName; } }

        public StudentViewModel(StudentModel model) : base(model) {

           

        }
    }
}
