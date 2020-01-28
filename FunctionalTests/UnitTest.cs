using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;


namespace FunctionalTests
{
    [TestClass]
    public class UnitTest1
    {

        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        WindowsDriver<WindowsElement> driver;

        

        [TestInitialize]
        public void Init()
        {

            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", "swz.app_qfppgxw3ky9mg!App");
           
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


        }

        [TestMethod]
        public void UseCase1()
        {
            UserButtonCLick();
            FindReplacementButtonCLick();
            Thread.Sleep(1000);
            InsertSearchCode("INZ");
            InsertSearchName("prog");
            InsertSearchFaculty("8");
            InsertSearchFieldOfStudy("inf");
            //SetCourseType("laboratorium");
            //SetLanguage("english");
            //SetStudyType("partTime");
            Thread.Sleep(1000);
            CheckFoundCourses(new string[] { "INZ1519L", "INZ1519Wc","INZ2528L","INZ2528Wc" });
            SelectCourse("INZ1519L");
            Thread.Sleep(2000);
            CheckFoundReplacements(new string[] { "INP002258Wl" });

            driver.CloseApp();
        }

        
        public void TestCleanup()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

        
        void UserButtonCLick()
        {
            var userButton = driver.FindElementByAccessibilityId("userButton");
            Assert.AreEqual(userButton.Text, "Użytkownik");
            userButton.Click();
        }

        
        void FindReplacementButtonCLick()
        {
            var userButton = driver.FindElementByAccessibilityId("findReplacementButton");
            Assert.AreEqual(userButton.Text, "Znajdź zamiennik");
            userButton.Click();
        }

        void InsertSearchName(string name)
        {
            var searchName = driver.FindElementByAccessibilityId("searchName");
            searchName.SendKeys(name);

         
        }

        void InsertSearchFaculty(string name)
        {
            var searchFaculty = driver.FindElementByAccessibilityId("searchFaculty");
            searchFaculty.SendKeys(name);
        }

        void InsertSearchCode(string name)
        {
            var searchCode = driver.FindElementByAccessibilityId("searchCode");
            searchCode.SendKeys(name);
        }

        void InsertSearchFieldOfStudy(string name)
        {
            var searchField = driver.FindElementByAccessibilityId("searchFieldOfStudy");
            searchField.SendKeys(name);
        }

        [Obsolete]
        void SetCourseType(string name)
        {
            var searchType = driver.FindElementByAccessibilityId("SearchCourseType");
            searchType.Click();
            var cbitems = searchType.FindElementsByClassName("ComboBoxItem");

            
            Thread.Sleep(1000);
            int i = 0;
            while (!cbitems[i].Text.Equals(name))
            {
                driver.Keyboard.PressKey(Keys.Down);
                i++;
            }

            cbitems[i].Click();
           

        }

        void SetLanguage(string name)
        {   
            
            var polish = driver.FindElementByAccessibilityId("langPolish");
            var english = driver.FindElementByAccessibilityId("langEnglish");

            if(name.Equals("polish"))
            {
                polish.Click();
            }
            else
            {
                english.Click();
            }
        }

        void SetStudyType(string name)
        {

            var fullTime = driver.FindElementByAccessibilityId("fullTime");
            var partTime = driver.FindElementByAccessibilityId("partTime");

            if (name.Equals("fullTime"))
            {
                fullTime.Click();
            }
            else
            {
                partTime.Click();
            }
        }

        void SelectCourse(string code)
        {
            var courses = driver.FindElementsByXPath("//List[@AutomationId=\"Courses\"]/ListItem[@Name='SWZ.ViewModels.CourseViewModel']");
            var groups = driver.FindElementsByXPath("//List[@AutomationId=\"Courses\"]/ListItem[@Name='SWZ.ViewModels.CoursesGroupViewModel']");

            foreach(var c in courses)
            {
                if (c.FindElementByAccessibilityId("Code").Text.Equals(code))
                {
                    c.Click();
                    return;
                }
            }
            foreach (var g in courses)
            {
                if (g.FindElementByAccessibilityId("Code").Text.Equals(code))
                {
                    g.Click();
                    return;
                }
            }
            Assert.Fail();

        }

        void CheckFoundReplacements(string[] codesExpected=null)
        {
            var replacements = driver.FindElementsByXPath("//List[@AutomationId=\"Replacements\"]/ListItem[@Name='SWZ.ViewModels.ReplacementViewModel']");
            
            foreach(var code in codesExpected)
            {
                bool found = false;
                foreach(var replacement in replacements)
                {
                    var replacementCourses = replacement.FindElementsByAccessibilityId("ReplacementCourses");
                    foreach(var course in replacementCourses)
                    {
                        var repCode = course.FindElementByAccessibilityId("Code").Text;
                        if (repCode.Equals(code)) found = true;
                    }
                   
                   
                }

                Assert.IsTrue(found);
            }
        }

        void CheckFoundCourses(string[] codesExpected = null)
        {
            //var coursesListView = driver.FindElementByAccessibilityId("Courses");

           
            var courses = driver.FindElementsByXPath("//List[@AutomationId=\"Courses\"]/ListItem[@Name='SWZ.ViewModels.CourseViewModel']");
            var groups = driver.FindElementsByXPath("//List[@AutomationId=\"Courses\"]/ListItem[@Name='SWZ.ViewModels.CoursesGroupViewModel']");

            



            Assert.IsNotNull(courses);
            if (codesExpected != null)
            {
                Assert.IsTrue(courses.Count > 0 && groups.Count > 0);

                foreach (string code in codesExpected)
                {
                    bool found = false;
                    foreach (var lvitem in courses)
                    {
                        if (lvitem != null)
                        {

                            var codeTextBox = lvitem.FindElementByAccessibilityId("Code");
                            if (codeTextBox.Text.Equals(code)) found = true;
                        }


                    }

                    foreach (var lvitem in groups)
                    {
                        if (lvitem != null)
                        {

                            var codeTextBox = lvitem.FindElementByAccessibilityId("Code");
                            if (codeTextBox.Text.Equals(code)) found = true;
                        }


                    }
                    Assert.IsTrue(found);
                }
            }
            else
            {
                Assert.IsTrue(courses.Count == 0 && groups.Count == 0);
            }
            
            
           

        }



    }
}
