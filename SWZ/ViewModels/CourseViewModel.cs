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
            get { return this_.code; }
            set { SetProperty(this_.code, value, () => this_.code = value); }
        }
        public string Name
        {
            get { return this_.name; }
            set { SetProperty(this_.code, value, () => this_.code = value); }
        }
        public int ECTS
        {
            get { return this_.ects; }
            set { SetProperty(this_.ects, value, () => this_.ects = value); }
        }
        public int ZZU
        {
            get { return this_.zzu; }
            set { SetProperty(this_.zzu, value, () => this_.zzu = value); }
        }
        public int SemesterNumber
        {
            get { return this_.semesterNumber; }
            set { SetProperty(this_.semesterNumber, value, () => this_.semesterNumber = value); }
        }
        public string Type
        {
            get { return this_.courseType.ToString(); }
        }
        public string FacultySymbol
        {
            get { return this_.studyPlan.facultySymbol; }
        }
        public string FieldOfStudy
        {
            get { return this_.studyPlan.fieldOfStudies; }
        }
        public StudyDegree StudyDegree
        {
            get { return this_.studyPlan.studyDegree; }
        }
        public StudyType StudyType
        {
            get { return this_.studyPlan.studyType; }
        }
        public Language Language
        {
            get { return this_.studyPlan.language; }
        }

    }
}
