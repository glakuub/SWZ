using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWZ.Models;
namespace SWZ.ViewModels
{
    class CourseViewModel : NotificationBase<CourseModel>
    {
        public CourseViewModel(CourseModel course = null) : base(course) { }
        public string Code
        {
            get { return this_.Code; }
            set { SetProperty(this_.Code, value, () => this_.Code = value); }
        }
        public string Name
        {
            get { return this_.Name; }
            set { SetProperty(this_.Code, value, () => this_.Code = value); }
        }
        public int ECTS
        {
            get { return this_.Ects; }
            set { SetProperty(this_.Ects, value, () => this_.Ects = value); }
        }
        public int ZZU
        {
            get { return this_.Zzu; }
            set { SetProperty(this_.Zzu, value, () => this_.Zzu = value); }
        }
        public int SemesterNumber
        {
            get { return this_.SemesterNumber; }
            set { SetProperty(this_.SemesterNumber, value, () => this_.SemesterNumber = value); }
        }
        
        public string FacultySymbol
        {
            get { return this_.StudyPlan.facultySymbol; }
        }
        public string FieldOfStudy
        {
            get { return this_.StudyPlan.fieldOfStudies; }
        }
        public CourseType Type
        {
            get { return this_.CourseType; }
        }
        public StudyDegree StudyDegree
        {
            get { return this_.StudyPlan.studyDegree; }
        }
        public StudyType StudyType
        {
            get { return this_.StudyPlan.studyType; }
        }
        public Language Language
        {
            get { return this_.StudyPlan.language; }
        }

    }
}
