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
        public StudentViewModel(StudentModel model) : base(model) { }
    }
}
