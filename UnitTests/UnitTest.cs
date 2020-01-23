
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWZ.DAL.Courses;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        static readonly int _id = 5;
        static readonly string _name = "Podstawy Programowania (GK)";
        static readonly string _code = "INZ1519Wc";
        static readonly int _subcoursesCount = 2;

        [TestMethod]
        public void TestMethod1()
        {
            ICourseDAO courseDao = new MSSQLCourseDAO();
            var dto = courseDao.FindCourseById(_id);
            var model = Mapper.FromDTO(dto);

            Assert.AreEqual(_id, model.Id);
            Assert.AreEqual(_name, model.Name);
            Assert.AreEqual(_code, model.Code );
            Assert.AreEqual(_subcoursesCount, model.GetCoursesCount());
            
        }
    }
}
