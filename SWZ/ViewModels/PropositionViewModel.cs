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

        public String Date { set { this_.dateOfSubmission = DateTime.Parse(value); } get { return this_.dateOfSubmission.ToString(); } }
        public CourseViewModel Course { set; get; }
        public StudentViewModel Student { set; get; }

        ObservableCollection<CourseViewModel> _replacements;

        public PropositionViewModel(PropositionModel model = null):base(model)
        {
            if (model != null)
            {
                Course = new CourseViewModel(model.replacing);
                Student = new StudentViewModel(model.proposing);
                if(model.replacements!=null)
                foreach (CourseModel cm in model.replacements)
                {
                    _replacements.Add(new CourseViewModel(cm));
                }
            }
        }
    }
}
