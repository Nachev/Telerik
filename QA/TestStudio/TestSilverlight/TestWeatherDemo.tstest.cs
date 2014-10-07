using Telerik.TestingFramework.Controls.KendoUI;
using Telerik.WebAii.Controls.Html;
using Telerik.WebAii.Controls.Xaml;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts;
using ArtOfTest.WebAii.Design;
using ArtOfTest.WebAii.Design.Execution;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

namespace TestSilverlight
{

    public class TestWeatherDemo : BaseWebAiiTest
    {
        #region [ Dynamic Pages Reference ]

        private Pages _pages;

        /// <summary>
        /// Gets the Pages object that has references
        /// to all the elements, frames or regions
        /// in this project.
        /// </summary>
        public Pages Pages
        {
            get
            {
                if (_pages == null)
                {
                    _pages = new Pages(Manager.Current);
                }
                return _pages;
            }
        }

        #endregion
        
        // Add your test methods here...
    
        [CodedStep(@"Verify 'WatherDate' text Same 'OCT 06, 2014'", RequiresSilverlight=true)]
        public void TestWeatherDemo_CodedStep()
        {
            // Verify 'WatherDate' text Same '{current date}'
            string weatherDate = Pages.WeatherGaugeForSilverlight.SilverlightApp.WatherDate.Text.ToLowerInvariant();
            string dateToday = DateTime.Now.ToString("MMM dd, yyyy", CultureInfo.CreateSpecificCulture("en-US")).ToLowerInvariant();
            Assert.IsTrue((ArtOfTest.Common.CompareUtils.StringCompare(weatherDate, dateToday, ArtOfTest.Common.StringCompareType.Same)), string.Format("Verify \'WatherDate\' text Same \'{1}\' failed.  Actual value \'{0}\'", weatherDate, dateToday));
            
        }
    }
}
