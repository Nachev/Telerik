namespace QA.Framework.Core.Base
{
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BaseTest
    {
        public Browser Browser
        {
            get
            {
                return Manager.Current.ActiveBrowser;
            }
        }

        public virtual void TestInitialize()
        {
        }

        public virtual void TestCleanUp()
        {
        }

        [TestInitialize]
        public void CoreTestInitialize()
        {
            this.Browser.ClearCache(BrowserCacheType.Cookies);
            this.Browser.Refresh();

            this.TestInitialize();       
        }

        [TestCleanup]
        public void CoreTestCleanup()
        {
            this.TestCleanUp();
        }

        public static void BaseClassInitialize()
        {
            if (Manager.Current == null)
            {
                var mySettings = new Settings();

                mySettings.DisableDialogMonitoring = false;
                mySettings.UnexpectedDialogAction = UnexpectedDialogAction.HandleAndContinue;
                mySettings.Web.DefaultBrowser = BrowserType.InternetExplorer;
                mySettings.Web.KillBrowserProcessOnClose = true;
                mySettings.Web.RecycleBrowser = true;
                mySettings.Web.BaseUrl = "http://test.telerikacademy.com/";

                var myManager = new Manager(mySettings);
                myManager.Start();
            }

            Manager.Current.LaunchNewBrowser();
        }

        public static void BaseClassCleanup()
        {
            foreach (var browser in Manager.Current.Browsers)
            {
                browser.Stop();
                browser.Close();
            }

            if (Manager.Current != null)
            {
                Manager.Current.Dispose();
            }
        }
    }
}