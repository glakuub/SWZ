using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SWZ.DAL.Replacements;
using SWZ.Models;

namespace UnitTests
{
    [TestClass]
    public class ReplacementMapperTest
    {
       
        [TestMethod]
        public void TestFromDTO()
        {
            //GIVEN

            int _replacedId = 2;
            int _replacementId = 7;
            string _replacedName = "Podstawy Programowania";
            string _replacedCode = "INZ1519L";
            string _replacementCode = "INP002258Wl";
            string _replacementName = "Kurs programowania";
            int _replacementsCount = 1;
            Mock<IReplacementDAO> replacementsDAOmock;
            ReplacementModel model;


            Replacement rep = new Replacement(_replacementId, _replacedId);
            replacementsDAOmock = new Mock<IReplacementDAO>();
            replacementsDAOmock.Setup(x => x.FindByReplacedId(rep.ReplacedID)).Returns(new List<Replacement>() { rep });

            model = new ReplacementModel();
            model.Replaced = new CourseModel() { Code = _replacementCode, Name = _replacedName };


            var dtoList = replacementsDAOmock.Object.FindByReplacedId(_replacedId);

            //WHEN
            var mappedModel = Mapper.FromDTO(dtoList[0]);
            
            //THEN
            Assert.AreEqual(_replacedCode, mappedModel.Replaced.Code);
            Assert.AreEqual(_replacedName, mappedModel.Replaced.Name);
            Assert.IsTrue(mappedModel.Replacements.Exists(r => r.Code == _replacementCode));
            Assert.IsTrue(mappedModel.Replacements.Exists(r => r.Name == _replacementName));

            

        }

       
    }
}
