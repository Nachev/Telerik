using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.TestAttributes;
using ArtOfTest.WebAii.TestTemplates;
using ArtOfTest.WebAii.Win32.Dialogs;

using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSearchFeature
{
    /// <summary>
    /// 1.	Test Search in http://telerikacademy.com/ 
    ///  - WPF returns 2 cources and 1 track
    ///  - Quality returns 1 user, 5 cources and 1 track
    ///  - Webaii does not return results
    /// </summary>
    [TestClass]
    public class TestSearchFeature : BaseTest
    {
        #region [Setup / TearDown]
        private TestContext testContextInstance = null;
        /// <summary>
        ///Gets or sets the VS test context which provides
        ///information about and functionality for the
        ///current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
        }

        // Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            #region WebAii Initialization

            // Initializes WebAii manager to be used by the test case.
            // If a WebAii configuration section exists, settings will be
            // loaded from it. Otherwise, will create a default settings
            // object with system defaults.
            //
            // Note: We are passing in a delegate to the VisualStudio
            // testContext.WriteLine() method in addition to the Visual Studio
            // TestLogs directory as our log location. This way any logging
            // done from WebAii (i.e. Manager.Log.WriteLine()) is
            // automatically logged to the VisualStudio test log and
            // the WebAii log file is placed in the same location as VS logs.
            //
            // If you do not care about unifying the log, then you can simply
            // initialize the test by calling Initialize() with no parameters;
            // that will cause the log location to be picked up from the config
            // file if it exists or will use the default system settings (C:\WebAiiLog\)
            // You can also use Initialize(LogLocation) to set a specific log
            // location for this test.

            // Pass in 'true' to recycle the browser between test methods
            Initialize(false, this.TestContext.TestLogsDir, new TestContextWriteLine(this.TestContext.WriteLine));

            // If you need to override any other settings coming from the
            // config section you can comment the 'Initialize' line above and instead
            // use the following:

            /*

            // This will get a new Settings object. If a configuration
            // section exists, then settings from that section will be
            // loaded

            Settings settings = GetSettings();

            // Override the settings you want. For example:
            settings.Web.DefaultBrowser = BrowserType.FireFox;

            // Now call Initialize again with your updated settings object
            Initialize(settings, new TestContextWriteLine(this.TestContext.WriteLine));

            */

            // Set the current test method. This is needed for WebAii to discover
            // its custom TestAttributes set on methods and classes.
            // This method should always exist in [TestInitialize()] method.
            SetTestMethod(this, (string)TestContext.Properties["TestName"]);

            #endregion

            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {

            ActiveBrowser.Close();

            #region WebAii CleanUp

            // Shuts down WebAii manager and closes all browsers currently running
            // after each test. This call is ignored if recycleBrowser is set
            this.CleanUp();

            #endregion
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            // This will shut down all browsers if
            // recycleBrowser is turned on. Else
            // will do nothing.
            ShutDown();
        }

        #endregion

        [TestMethod]
        public void TestWithWpf()
        {
            int coursesExpectedCount = 2;
            int tracksExpectedCount = 1;

            string coursesName = "�������";
            string tracksName = "�������";
            string text = "WPF";

            ActiveBrowser.NavigateTo("http://telerikacademy.com/");
            SearchForText(text);

            var coursesCount = GetResultSubareaCount(coursesName);

            Assert.AreEqual(coursesExpectedCount, coursesCount, "Wrong courses count.");

            var tracksCount = GetResultSubareaCount(tracksName);

            Assert.AreEqual(tracksExpectedCount, tracksCount, "Wrong track count.");
        }

        [TestMethod]
        public void TestWithQuality()
        {
            int usersExpectedCount = 1;
            int coursesExpectedCount = 5;
            int tracksExpectedCount = 1;

            string coursesName = "�������";
            string tracksName = "�������";
            string usersName = "�����������";
            string text = "Quality ";

            ActiveBrowser.NavigateTo("http://telerikacademy.com/");
            SearchForText(text);

            var coursesCount = GetResultSubareaCount(coursesName);

            Assert.AreEqual(coursesExpectedCount, coursesCount, "Wrong courses count.");

            var tracksCount = GetResultSubareaCount(tracksName);

            Assert.AreEqual(tracksExpectedCount, tracksCount, "Wrong track count.");

            var usersCount = GetResultSubareaCount(usersName);

            Assert.AreEqual(usersExpectedCount, usersCount, "Wrong users count.");
        }

        [TestMethod]
        public void TestWithWebAii()
        {
            int usersExpectedCount = 1;
            int coursesExpectedCount = 0;
            int tracksExpectedCount = 0;

            string coursesName = "�������";
            string tracksName = "�������";
            string usersName = "�����������";
            string text = "WebAii ";

            ActiveBrowser.NavigateTo("http://telerikacademy.com/");
            SearchForText(text);

            var coursesCount = GetResultSubareaCount(coursesName);

            Assert.AreEqual(coursesExpectedCount, coursesCount, "Wrong courses count.");

            var tracksCount = GetResultSubareaCount(tracksName);

            Assert.AreEqual(tracksExpectedCount, tracksCount, "Wrong track count.");

            var usersCount = GetResultSubareaCount(usersName);

            Assert.AreEqual(usersExpectedCount, usersCount, "Wrong users count.");
        }

        private void SearchForText(string text)
        {
            Find.ById<HtmlInputText>("SearchTerm").Text = text;
            Find.ById<HtmlInputSubmit>("SearchButton").Click();
        }
 
        private int GetResultSubareaCount(string tracksName)
        {
            var resultDivs = Find.ById<HtmlControl>("MainContent").Find.AllByAttributes<HtmlDiv>("class=SearchResultsCategory");
            var tracksArea = resultDivs.FirstOrDefault(e => e.Find
                                                             .ByAttributes<HtmlContainerControl>("class=SearchResultsCategoryTitle")
                                                             .InnerText
                                                             .Contains(tracksName));
            if (tracksArea == null)
            {
                return 0;
            }

            var tracksCount = tracksArea.Find.ByAttributes<HtmlUnorderedList>("class=SearchMetroList").Find.AllByTagName("li").Count;
            return tracksCount;
        }
    }
}
