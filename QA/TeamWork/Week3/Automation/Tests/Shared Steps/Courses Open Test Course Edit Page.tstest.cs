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

    public class Courses_Open_Test_Course_Edit_Page : BaseWebAiiTest
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
    
        //[CodedStep(@"New Coded Step")]
        //public void Courses_Open_Test_Course_Edit_Page_CodedStep()
        //{
            //Find.ByXPath<HtmlControl>("//id('DataGrid')/table/tbody/")
                            //.Find.AllByTagName<HtmlTableRow>("tr")
                            //.Where(row => row.InnerText.Contains("Users Module Testing Course")).FirstOrDefault()
                            //.Find.ByXPath<HtmlSpan>("/td[16]/a/span")
                            //.Click();
        //}
    
        //[CodedStep(@"New Coded Step")]
        //public void Courses_Open_Test_Course_Edit_Page_CodedStep()
        //{
            //Find.ByXPath<HtmlAnchor>("//*[@id='DataGrid']/table/tbody/tr[td/a/@href ='/Courses/Courses/Details/24']/td[16]/a").Click();
        //}
    }
}
