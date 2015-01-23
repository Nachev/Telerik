using Telerik.TestingFramework.Controls.KendoUI;
using Telerik.WebAii.Controls.Html;
using Telerik.WebAii.Controls.Xaml;
using System;
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

namespace Automation
{

    public class Register_new_test_user : BaseWebAiiTest
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
    
        [CodedStep(@"New Coded Step")]
        public void Register_new_test_user_CodedStep()
        {
            var dateTime = DateTime.Now;
            var uniqueName = "Test" + dateTime.ToString("HHmmddMMyyyy");
            SetExtractedValue("uniqueName", uniqueName);
        }
    
        [CodedStep(@"Enter text 'uniqueName@test.com' in 'EmailField'")]
        public void Register_new_test_user_CodedStep1()
        {
            // Enter text 'uniqueName@test.com' in 'EmailField'
            var uniqueName = GetExtractedValue("uniqueName");
            Actions.SetText(Pages.RegistrationPage.EmailField, uniqueName.ToString() + "@test.com");
            
        }
    }
}
