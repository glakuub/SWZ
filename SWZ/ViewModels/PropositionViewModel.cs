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
        public CourseViewModel Course { set { this_.Replacing = value.Model; } get { return new CourseViewModel(this_.Replacing); } }
        public StudentViewModel Student { set { this_.Proposing = value.Model; } get { return new StudentViewModel(this_.Proposing); } }

        public ObservableCollection<CourseViewModel> Replacements {
            set
            {
                List<CourseModel> cmlist = new List<CourseModel>();
                foreach (CourseViewModel cvm in value)
                {
                    cmlist.Add(cvm.Model);
                };
                this_.Replacements = cmlist;
            }
            get
            {
                ObservableCollection<CourseViewModel> cvmlist = new ObservableCollection<CourseViewModel>();
                foreach (CourseModel cm in this_.Replacements)
                {
                    cvmlist.Add(new CourseViewModel(cm));
                }
                return cvmlist;
            }
        }

        public void Save() => this_.Save();

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
