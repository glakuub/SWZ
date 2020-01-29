
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SWZ.DAL.Courses;
using SWZ.Models;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void TestFromDTOCourse()
        {   
            //GIVEN
            int _courseId = 2;
            string _name = "Podstawy Programowania";
            string _code = "INZ1519L";
            int _ects = 2;
            int _courseType = 3;
            int _courseZzu = 15;
            int _courseSemesterNumber = 1;
            int _studyPlanId = 2;
            int? _coursesGroupID = null;
            bool _isCoursesGroup = false;
            Mock<ICourseDAO> courseDAOmock;

            courseDAOmock = new Mock<ICourseDAO>();
            courseDAOmock.Setup(m => m.FindCourseById(_courseId)).Returns(new Course()
            {
                Id = _courseId,
                CourseCode = _code,
                CourseName = _name,
                Ects = _ects,
                CourseType = _courseType,
                Zzu = _courseZzu,
                SemesterNumber = _courseSemesterNumber,
                StudyPlanID = _studyPlanId,
                CoursesGroupID = _coursesGroupID,
                IsCoursesGroup = _isCoursesGroup
            });


            ICourseDAO courseDao = courseDAOmock.Object;
            var dto = courseDao.FindCourseById(_courseId);

            //WHEN
            var model = Mapper.FromDTO(dto) as CourseModel;


            //THEN
            Assert.AreEqual(_courseId, model.Id);
            Assert.AreEqual(_name, model.Name);
            Assert.AreEqual(_code, model.Code );
            Assert.AreEqual(_ects, model.Ects );
            Assert.AreEqual((CourseType)_courseType, model.CourseType );
            Assert.AreEqual(_courseZzu, model.Zzu );
            Assert.AreEqual(_courseSemesterNumber, model.SemesterNumber );
            Assert.AreEqual(_studyPlanId, model.StudyPlan.id );
            
           
            
        }

        [TestMethod]
        public void TestFromDTOCoursesGroup()
        {
            //GIVEN
            int _courseId = 5;
            string _name = "Podstawy Programowania (GK)";
            string _code = "INZ1519Wc";
            int _ects = 4;
            int _courseType = 5;
            int _courseZzu = 60;
            int _courseSemesterNumber = 1;
            int _studyPlanId = 2;
            int? _coursesGroupID = null;
            bool _isCoursesGroup = true;
            Mock<ICourseDAO> courseDAOmock;

            string[] _subCoursesCodes = new string[] { "INZ1519C", "INZ1519W" };

            courseDAOmock = new Mock<ICourseDAO>();
            courseDAOmock.Setup(m => m.FindCourseById(_courseId)).Returns(new Course()
            {
                Id = _courseId,
                CourseCode = _code,
                CourseName = _name,
                Ects = _ects,
                CourseType = _courseType,
                Zzu = _courseZzu,
                SemesterNumber = _courseSemesterNumber,
                StudyPlanID = _studyPlanId,
                CoursesGroupID = _coursesGroupID,
                IsCoursesGroup = _isCoursesGroup
            });


            ICourseDAO courseDao = courseDAOmock.Object;
            var dto = courseDao.FindCourseById(_courseId);

            //WHEN
            var model = Mapper.FromDTO(dto) as CoursesGroupModel;


            //THEN
            Assert.AreEqual(_courseId, model.Id);
            Assert.AreEqual(_name, model.Name);
            Assert.AreEqual(_code, model.Code);
            Assert.AreEqual(_ects, model.Ects);
            Assert.AreEqual((CourseType)_courseType, model.CourseType);
            Assert.AreEqual(_courseZzu, model.Zzu);
            Assert.AreEqual(_courseSemesterNumber, model.SemesterNumber);
            Assert.AreEqual(_studyPlanId, model.StudyPlan.id);
                
           foreach(string subCode in _subCoursesCodes)
            {
                model.GetCourses().Exists(cm => cm.Code == subCode);
            }


        }
    }
}
