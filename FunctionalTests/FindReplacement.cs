using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;


namespace UnitTestProject1
{
    [TestClass]
    public class FindReplacementTest
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

        [DataTestMethod]
        [DataRow("INZ", "prog", "8", "inf", "dowolny", "polski", "stacjonarne", new string[] { "INZ1519L", "INZ1519Wc", "INZ2528L", "INZ2528Wc" }, "INZ1519L", new string[] { "INP002258Wl" })]
        [DataRow("INZ", "prog", "8", "inf", "wykład", "angielski", "niestacjonarne", null, null, null)]
        [DataRow(null, "prog", null, "inf", "laboratorium", "polski", "stacjonarne", new string[] { "INZ1519L", "INZ2528L" }, "INZ1519L", new string[] { "INP002258Wl" })]
        [DataRow(null, "elek", null, null, null, null, null, new string[] { "INZ1516W" }, "INZ1516W", null)]
        [DataRow(null, "alg", null, null, "laboratorium", null, null, new string[] { "INZ1517L" }, "INZ1517L", null)]
        [DataRow(null, "elek", null, null, null, null, null, new string[] { "INZ1516W" }, "INZ1516W", null)]
        [DataRow("map002206wc", null, null, null, null, null, null, new string[] { "map002206wc" }, "map002206wc", new string[] { "maz1500c", "maz1500w" })]
        [DataRow(null, null, "w08", null, null, null, null, new string[] { "INZ1518C", "INZ1519L", "INZ1519Wc", "INZ1519W" }, "INZ1519Wc", null)]
        [DataRow(null, "dan", "w11", null, null, null, null, new string[] { "INP002263Wcl" }, "INP002263Wcl", new string[] { "INZ1517L", "INZ1517Wc" })]
        [DataRow(null, null, null, null, null, "angielski", "niestacjonarne", null, null, null)]
        public void FindReplacementSequence(string code, string name, string faculty, string field, string courseType, string lang,
            string studyType, string[] expectedCourses, string toSelect, string[] expectedReplacements)
        {

            UserButtonCLick();
            Thread.Sleep(1000);
            FindReplacementButtonCLick();
            Thread.Sleep(2000);

            InsertSearchCode(code);
            InsertSearchName(name);
            InsertSearchFaculty(faculty);
            InsertSearchFieldOfStudy(field);
            SetCourseType(courseType);
            SetLanguage(lang);
            SetStudyType(studyType);
            Thread.Sleep(2000);

            CheckFoundCourses(expectedCourses);
            SelectCourse(toSelect);
            Thread.Sleep(3000);

            CheckFoundReplacements(expectedReplacements);

        }


        [TestCleanup]
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

        void InsertSearchName(string name = null)
        {
            if (name != null)
            {
                var searchName = driver.FindElementByAccessibilityId("searchName");
                searchName.SendKeys(name);
            }

        }

        void InsertSearchFaculty(string name = null)
        {
            if (name != null)
            {
                var searchFaculty = driver.FindElementByAccessibilityId("searchFaculty");
                searchFaculty.SendKeys(name);
            }
        }

        void InsertSearchCode(string name = null)
        {
            if (name != null)
            {
                var searchCode = driver.FindElementByAccessibilityId("searchCode");
                searchCode.SendKeys(name);
            }
        }

        void InsertSearchFieldOfStudy(string name = null)
        {
            if (name != null)
            {
                var searchField = driver.FindElementByAccessibilityId("searchFieldOfStudy");
                searchField.SendKeys(name);
            }
        }

        [Obsolete]
        void SetCourseType(string name = null)
        {
            if (name != null)
            {
                var searchType = driver.FindElementByAccessibilityId("SearchCourseType");
                searchType.Click();
                var cbitems = searchType.FindElementsByClassName("ComboBoxItem");


                Thread.Sleep(1000);
                int i = 0;
                while (!cbitems[i].Text.ToUpper().Equals(name.ToUpper()))
                {
                    driver.Keyboard.PressKey(Keys.Down);
                    i++;
                }

                cbitems[i].Click();
            }

        }

        void SetLanguage(string name = null)
        {
            if (name != null)
            {
                var polish = driver.FindElementByAccessibilityId("langPolish");
                var english = driver.FindElementByAccessibilityId("langEnglish");

                if (name.ToUpper().Equals("POLSKI"))
                {
                    polish.Click();
                }
                else
                {
                    english.Click();
                }
            }
        }

        void SetStudyType(string name = null)
        {
            if (name != null)
            {
                var fullTime = driver.FindElementByAccessibilityId("fullTime");
                var partTime = driver.FindElementByAccessibilityId("partTime");

                if (name.ToUpper().Equals("STACJONARNE"))
                {
                    fullTime.Click();
                }
                else
                {
                    partTime.Click();
                }
            }
        }

        void SelectCourse(string code = null)
        {

            if (code != null)
            {
                var courses = driver.FindElementsByXPath("//List[@AutomationId=\"Courses\"]/ListItem[@Name='SWZ.ViewModels.CourseViewModel']");
                var groups = driver.FindElementsByXPath("//List[@AutomationId=\"Courses\"]/ListItem[@Name='SWZ.ViewModels.CoursesGroupViewModel']");

                foreach (var c in courses)
                {
                    if (c.FindElementByAccessibilityId("Code").Text.ToUpper().Equals(code.ToUpper()))
                    {
                        c.Click();
                        return;
                    }
                }
                foreach (var g in groups)
                {
                    if (g.FindElementByAccessibilityId("Code").Text.ToUpper().Equals(code.ToUpper()))
                    {
                        g.Click();
                        return;
                    }
                }
                Assert.Fail();
            }

        }

        void CheckFoundReplacements(string[] codesExpected = null)
        {
            var replacements = driver.FindElementsByXPath("//List[@AutomationId=\"Replacements\"]/ListItem[@Name='SWZ.ViewModels.ReplacementViewModel']");

            if (codesExpected != null)
            {


                foreach (var code in codesExpected)
                {
                    bool found = false;
                    foreach (var replacement in replacements)
                    {
                        //var replacementCourses = replacement.FindElementByAccessibilityId("ReplacementCourses");
                        //var replacementCourses = replacement.FindElementsByClassName("ListView");
                        var replacementCourses = replacement.FindElementsByXPath("//List[@AutomationId=\"ReplacementCourses\"]/ListItem[@Name='SWZ.ViewModels.CourseViewModel']");
                        foreach (var course in replacementCourses)
                        {
                            var repCode = course.FindElementByAccessibilityId("Code").Text;
                            if (repCode.ToUpper().Equals(code.ToUpper())) found = true;
                        }

                        var replacementGroups = replacement.FindElementsByXPath("//List[@AutomationId=\"ReplacementCourses\"]/ListItem[@Name='SWZ.ViewModels.CoursesGroupViewModel']");
                        foreach (var group in replacementGroups)
                        {
                            var repCode = group.FindElementByAccessibilityId("Code").Text;
                            if (repCode.ToUpper().Equals(code.ToUpper())) found = true;
                        }


                    }

                    Assert.IsTrue(found);
                }
            }
            else
            {
                Assert.AreEqual(0, replacements.Count);
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
                Assert.IsTrue(courses.Count > 0 || groups.Count > 0);

                foreach (string code in codesExpected)
                {
                    bool found = false;
                    foreach (var lvitem in courses)
                    {
                        if (lvitem != null)
                        {

                            var codeTextBox = lvitem.FindElementByAccessibilityId("Code");
                            if (codeTextBox.Text.ToUpper().Equals(code.ToUpper())) found = true;
                        }


                    }

                    foreach (var lvitem in groups)
                    {
                        if (lvitem != null)
                        {

                            var codeTextBox = lvitem.FindElementByAccessibilityId("Code");
                            if (codeTextBox.Text.ToUpper().Equals(code.ToUpper())) found = true;
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
