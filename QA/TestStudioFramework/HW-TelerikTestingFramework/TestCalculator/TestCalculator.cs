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

namespace TestCalculator
{
    /// <summary>
    /// Test calculator http://www.webestools.com/ftp/ybouane/scripts_tutorials/javascript/calculator/calculator.html	
    ///  - Make tests that covers all functionality
    /// </summary>
    [TestClass]
    public class TestCalculator : BaseTest
    {
        private const string BaseUrl = @"http://www.webestools.com/ftp/ybouane/scripts_tutorials/javascript/calculator/calculator.html";

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
        public void TestSumCalculation()
        {
            string expectedResult = "3";

            ActiveBrowser.NavigateTo(BaseUrl);

            var calculator = Find.ById<HtmlTable>("calc");
            var display = calculator.Find.ById<HtmlInputText>("calc_result");

            var one = GetButtonByValue(calculator, "1");
            one.Click();
            Assert.AreEqual("1", display.Value);

            var plus = GetButtonByValue(calculator, "+");
            plus.Click();

            var two = GetButtonByValue(calculator, "2");
            two.Click();
            Assert.AreEqual("2", display.Value);

            var equals = GetButtonByValue(calculator, "=");
            equals.Click();

            Assert.AreEqual(expectedResult, display.Value);
        }

        [TestMethod]
        public void TestSubtractCalculation()
        {
            string expectedResult = "1";

            ActiveBrowser.NavigateTo(BaseUrl);

            var calculator = Find.ById<HtmlTable>("calc");
            var display = calculator.Find.ById<HtmlInputText>("calc_result");

            ClickAndVerify(calculator, display, "4", "4");

            ClickAndVerify(calculator, display, "-");

            ClickAndVerify(calculator, display, "3", "3");

            ClickAndVerify(calculator, display, "=", expectedResult);
        }

        [TestMethod]
        public void TestMultiplyCalculation()
        {
            string expectedResult = "30";

            ActiveBrowser.NavigateTo(BaseUrl);

            var calculator = Find.ById<HtmlTable>("calc");
            var display = calculator.Find.ById<HtmlInputText>("calc_result");

            ClickAndVerify(calculator, display, "5", "5");

            ClickAndVerify(calculator, display, "x");

            ClickAndVerify(calculator, display, "6", "6");

            ClickAndVerify(calculator, display, "=", expectedResult);
        }

        [TestMethod]
        public void TestDivideCalculation()
        {
            string expectedResult = "0.875";

            ActiveBrowser.NavigateTo(BaseUrl);

            var calculator = Find.ById<HtmlTable>("calc");
            var display = calculator.Find.ById<HtmlInputText>("calc_result");

            ClickAndVerify(calculator, display, "7", "7");

            ClickAndVerify(calculator, display, "÷");

            ClickAndVerify(calculator, display, "8", "8");

            ClickAndVerify(calculator, display, "=", expectedResult);
        }

        [TestMethod]
        public void TestDivideByZeroCalculation()
        {
            string expectedResult = "Cannot divide by zero";

            ActiveBrowser.NavigateTo(BaseUrl);

            var calculator = Find.ById<HtmlTable>("calc");
            var display = calculator.Find.ById<HtmlInputText>("calc_result");

            ClickAndVerify(calculator, display, "9", "9");

            ClickAndVerify(calculator, display, "÷");

            ClickAndVerify(calculator, display, "0", "0");

            ClickAndVerify(calculator, display, "=", expectedResult);
        }

        [TestMethod]
        public void TestFractionsSumCalculation()
        {
            string expectedResult = "4.6";

            ActiveBrowser.NavigateTo(BaseUrl);

            var calculator = Find.ById<HtmlTable>("calc");
            var display = calculator.Find.ById<HtmlInputText>("calc_result");

            ClickAndVerify(calculator, display, "1", "1");
            ClickAndVerify(calculator, display, ",", "1.");
            ClickAndVerify(calculator, display, "2", "1.2");

            ClickAndVerify(calculator, display, "+");

            ClickAndVerify(calculator, display, "3", "3");
            ClickAndVerify(calculator, display, ",", "3.");
            ClickAndVerify(calculator, display, "4", "3.4");

            ClickAndVerify(calculator, display, "=", expectedResult);
        }

        [TestMethod]
        public void TestNegativeElementsSumCalculation()
        {
            string expectedResult = "-11";

            ActiveBrowser.NavigateTo(BaseUrl);

            var calculator = Find.ById<HtmlTable>("calc");
            var display = calculator.Find.ById<HtmlInputText>("calc_result");

            ClickAndVerify(calculator, display, "5", "5");
            ClickAndVerify(calculator, display, "±", "-5");

            ClickAndVerify(calculator, display, "+");

            ClickAndVerify(calculator, display, "6", "6");
            ClickAndVerify(calculator, display, "±", "-6");

            ClickAndVerify(calculator, display, "=", expectedResult);
        }

        [TestMethod]
        public void TestBackspaceFunction()
        {
            string expectedResult = "0";

            ActiveBrowser.NavigateTo(BaseUrl);

            var calculator = Find.ById<HtmlTable>("calc");
            var display = calculator.Find.ById<HtmlInputText>("calc_result");

            ClickAndVerify(calculator, display, "7", "7");
            ClickAndVerify(calculator, display, "8", "78");

            ClickAndVerify(calculator, display, "←", "7");

            ClickAndVerify(calculator, display, "←", expectedResult);
        }

        [TestMethod]
        public void TestClearFunction()
        {
            string expectedResult = "0";

            ActiveBrowser.NavigateTo(BaseUrl);

            var calculator = Find.ById<HtmlTable>("calc");
            var display = calculator.Find.ById<HtmlInputText>("calc_result");

            ClickAndVerify(calculator, display, "9", "9");
            ClickAndVerify(calculator, display, "0", "90");

            ClickAndVerify(calculator, display, "CE", expectedResult);
        }

        private void ClickAndVerify(HtmlTable calculator, HtmlInputText display, string click, string expect = null)
        {
            var button = GetButtonByValue(calculator, click);
            button.Click();

            if (expect == null)
            {
                return;
            }

            Assert.AreEqual(expect, display.Value);
        }

        private HtmlInputButton GetButtonByValue(HtmlTable calculator, string value)
        {
            var result = calculator.Find.ByAttributes<HtmlInputButton>("class=calc_btn", string.Format("value={0}", value));
            Assert.IsNotNull(result);
            return result;
        }
    }
}
