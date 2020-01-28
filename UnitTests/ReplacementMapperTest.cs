using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWZ.DAL.Replacements;

namespace UnitTests
{
    [TestClass]
    public class ReplacementMapperTest
    {
        static readonly int _replacedId = 2;
        static readonly int _replacementID = 1;
        static readonly string _name = "Podstawy Programowania";
        static readonly string _code = "INZ1519L";
        static readonly int _replacementsCount = 2;

        [TestMethod]
        public void TestMethod1()
        {
            var replacemntsDAO = new MSSQLReplacementDAO();
            var dtoList = replacemntsDAO.FindByReplacedId(_replacedId);

            Assert.AreEqual(_replacementsCount, dtoList.Count);
            var model = Mapper.FromDTO(dtoList.Find(dto => { return dto.Id == _replacementID; }));
            Assert.AreEqual(_code, model.Replaced.Code);
            Assert.AreEqual(_name, model.Replaced.Name);

            

        }

       
    }
}
