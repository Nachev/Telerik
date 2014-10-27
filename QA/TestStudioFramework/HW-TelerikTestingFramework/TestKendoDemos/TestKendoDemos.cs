using System;
using System.Collections.Generic;
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

namespace TestKendoDemos
{
    /// <summary>
    /// Summary description for TestKendoDemos
    /// </summary>
    [TestClass]
    public class TestKendoDemos : BaseTest
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
        public void TestKendo()
        {
            ActiveBrowser.NavigateTo(@"http://www.telerik.com/support/demos");
            int defaultWaitTime = 2500;
            int expectedColumnsCount = 5;
            int expectedRowsCount = 21;

            var demosLink = Find.ByExpression<HtmlAnchor>("TextContent=Launch Kendo UI demos", "class=Link--next");
            Assert.IsNotNull(demosLink);
            demosLink.Click();
            ActiveBrowser.WaitForElement(new HtmlFindExpression("XPath=//*[@id=\"widgets-all\"]/ul[1]/li[1]/ul/li[1]/a", "TextContent=Grid"), defaultWaitTime, false);
            Assert.AreEqual("http://demos.telerik.com/kendo-ui/", ActiveBrowser.Url);

            var gridLink = Find.ById<HtmlDiv>("widgets-all").Find.ByContent<HtmlAnchor>("Grid");
            Assert.IsNotNull(gridLink);
            gridLink.Click();

            var initFromTableLink = Find.ById<HtmlDiv>("example-nav").Find.ByContent<HtmlAnchor>("Initialization from table");
            Assert.IsNotNull(initFromTableLink);
            initFromTableLink.Click();

            var expression = new HtmlFindExpression("id=exampleTitle", "InnerText=~Initialization from table");
            var exampleTitle = ActiveBrowser.WaitForElement(expression, defaultWaitTime, false);
            Assert.IsNotNull(exampleTitle);

            var grid = Find.ById<HtmlDiv>("example");
            Assert.IsNotNull(grid);
            var columnsHeader = grid.Find.ByAttributes<HtmlDiv>("class=k-grid-header-wrap");
            var columnsCount = columnsHeader.Find.AllByExpression<HtmlControl>("class=k-header", "TagName=th").Count;
            Assert.AreEqual(expectedColumnsCount, columnsCount);

            var rowsCount = grid.Find.ById<HtmlTable>("grid").Find.AllByTagName<HtmlTableRow>("tr").Count;
            Assert.AreEqual(expectedRowsCount, rowsCount);

            var yearHeader = columnsHeader.Find.ByAttributes<HtmlTableCell>("data-field=year");
            yearHeader.Click();
            var sortArrow = ActiveBrowser.WaitForElement(
                defaultWaitTime, 
                "xpath=//*[@id='example']/div/div[1]/div/table/thead/tr/th[3]/a/span", 
                "class=k-icon k-i-arrow-n");
            Assert.IsNotNull(sortArrow);

            int rowCount = 1;
            int previousYear = new int();
            do
            {
                var yearCell = Find.ByXPath<HtmlTableCell>(string.Format("//*[@id='grid']/tbody/tr[{0}]/td[3]", rowCount));
                var currentYear = int.Parse(yearCell.TextContent);
                Assert.IsTrue(previousYear <= currentYear);
                previousYear = currentYear;
                currentYear = 0;
                rowCount++;
            } 
            while (rowCount < rowsCount);
        }
    }
}
