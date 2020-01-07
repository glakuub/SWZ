﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWZ.Models;

namespace SWZ.ViewModels
{
    class ReplacementViewModel: NotificationBase<ReplacementModel>
    {

        List<CourseViewModel> lcvm;
        public ReplacementViewModel(ReplacementModel replacement= null) : base(replacement)
        {
            lcvm = new List<CourseViewModel>();
            foreach (CourseModel cm in this_.Replacements)
            {
                lcvm.Add(new CourseViewModel(cm));
            }
        }

       

        public ReplacementViewModel()
        {
           
        }
        public string DateOfAuthorization
        {
            get { return this_.DateOfAuthorization.ToLongDateString(); }
          
        }
        public List<CourseViewModel> Courses
        {get{ return lcvm; } }
        

    }
}
