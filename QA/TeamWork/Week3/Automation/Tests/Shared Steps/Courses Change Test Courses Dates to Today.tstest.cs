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

    public class Courses_Change_Test_Courses_Dates_to_Today : BaseWebAiiTest
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
    
        //[CodedStep(@"KendoInputvalue '09/10/2014' entered.")]
        //public void Courses_Change_Test_Courses_Dates_to_Today_CodedStep()
        //{
            //// KendoInputvalue '09/10/2014' entered.
            //Pages.AdminCourseLecturesPage.CourseStartDate.TypeText(DateTime.Now.AddDays(1).ToString("dd/MM/yyyy").ToUpper());
            
        //}
    
        //[CodedStep(@"KendoInputvalue '10/10/2014' entered.")]
        //public void Courses_Change_Test_Courses_Dates_to_Today_CodedStep()
        //{
            //// KendoInputvalue '10/10/2014' entered.
            //Pages.AdminCourseLecturesPage.CourseEndDate.TypeText("10/10/2014");
            
        //}
    
        //[CodedStep(@"KendoInputvalue '10/10/2014 00:00:00' entered.")]
        //public void Courses_Change_Test_Courses_Dates_to_Today_CodedStep()
        //{
            //// KendoInputvalue '10/10/2014 00:00:00' entered.
            //Pages.AdminCourseLecturesPage.DeadlineForEnrollment.TypeText("10/10/2014 00:00:00");
            
        //}
    
        [CodedStep(@"Set start, end and registration dates")]
        public void CODED_ChangeDatesToToday()
        {
            Find.ById<HtmlInputText>("StartDate").Click();
            Find.ById<HtmlInputText>("StartDate").Text = DateTime.Now.ToString("dd/MM/yyyy").ToUpper();
            Find.ById<HtmlInputText>("StartDate").Click();
            
            Find.ById<HtmlInputText>("EndDate").Click();
            Find.ById<HtmlInputText>("EndDate").Text = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy").ToUpper();
            Find.ById<HtmlInputText>("EndDate").Click();
            
            Find.ById<HtmlInputText>("ApplyDeadline").Click();
            Find.ById<HtmlInputText>("ApplyDeadline").Text = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy").ToUpper() + " 00:00:00";
            Find.ById<HtmlInputText>("ApplyDeadline").Click();
        }
    
        //[CodedStep(@"KendoInputvalue '09/10/2014' entered.")]
        //public void Courses_Change_Test_Courses_Dates_to_Today_CodedStep()
        //{
            //// KendoInputvalue '09/10/2014' entered.
            //Pages.AdminCourseLecturesPage.CourseStartDate.TypeText("09/10/2014");
            
        //}
    }
}
