using SWZ.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.ViewModels
{
    class PropositionViewModel: NotificationBase<PropositionModel>
    {

        public String Date { set { this_.DateOfSubmission = DateTime.Parse(value); } get { return this_.DateOfSubmission.ToString(); } }
        public CourseViewModel Course { set; get; }
        public StudentViewModel Student { set; get; }

        public ObservableCollection<CourseViewModel> Replacements { set;  get; }

        public PropositionViewModel(PropositionModel model = null):base(model)
        {
            if (model != null)
            {
                Course = new CourseViewModel(model.Replacing);
                Student = new StudentViewModel(model.Proposing);
                if(model.Replacements!=null)
                foreach (CourseModel cm in model.Replacements)
                {
                    Replacements.Add(new CourseViewModel(cm));
                }
            }
        }
    }
}
