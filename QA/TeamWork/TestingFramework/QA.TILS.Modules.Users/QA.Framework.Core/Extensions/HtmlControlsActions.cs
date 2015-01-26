namespace QA.Framework.Core.Extensions
{
    using System;
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using QA.Framework.Core.Helpers;

    public static class HtmlControlsActions
    {
        public static T TypeText<T>(this T htmlControl, string textContent) where T : HtmlControl
        {
            MouseClickCustom(htmlControl);
            Manager.Current.Desktop.KeyBoard.TypeText(textContent, 0);

            return htmlControl;
        }

        public static T ReplaceTextWith<T>(this T htmlControl, string textContent) where T : HtmlControl
        {
            MouseClickCustom(htmlControl);
            Keyboard.DeleteFocusedFieldTextContent();
            Manager.Current.Desktop.KeyBoard.TypeText(textContent, 1);

            return htmlControl;
        }

        public static T MouseClickCustom<T>(this T htmlControl) where T : HtmlControl
        {
            htmlControl.ScrollToVisible(ScrollToVisibleType.ElementTopAtWindowTop);
            htmlControl.FireJQueryFocusEvent();
            htmlControl.MouseClick(MouseClickType.LeftClick);

            return htmlControl;
        }

        public static T ClickRepeatedly<T>(this T htmlControl, int numberOfTimes) where T : HtmlControl
        {
            for (int i = 0; i < numberOfTimes; i++)
            {
                htmlControl.FireJQueryClickEvent();
            }

            return htmlControl;
        }

        public static T AsKendoDatePickerSetDate<T>(this T htmlInputControl, int year, int month, int day) where T : HtmlInputControl
        {
            htmlInputControl.AssertIsVisible();
            string id = htmlInputControl.GetValue<string>("id");
            string jsFormat = @"$(""#{0}"").val(""{1}/{2}/{3} "");";
            string js = string.Format(jsFormat, id, day, month, year);
            Manager.Current.ActiveBrowser.Actions.InvokeScript(js);
            htmlInputControl.TypeText("00:00:00");

            return htmlInputControl;
        }

        public static T AsKendoDatePickerSetDate<T>(this T htmlInputControl, DateTime dateTime) where T : HtmlInputControl
        {
            htmlInputControl.AsKendoDatePickerSetDate(dateTime.Year, dateTime.Month, dateTime.Day);

            return htmlInputControl;
        }

        public static T AsKendoNumericBoxSetData<T>(this T htmlInputControl, double input) where T : HtmlInputControl
        {
            htmlInputControl.AssertIsNotNull();
            string id = htmlInputControl.GetValue<string>("id");
            string jsFormat = @"$(""#{0}"").data(""kendoNumericTextBox"").value({1:N2});";
            string js = string.Format(jsFormat, id, input);
            Manager.Current.ActiveBrowser.Actions.InvokeScript(js);
            htmlInputControl.FireJQueryChangeEvent();

            return htmlInputControl;
        }

        public static T EnterValueWithChangeEvent<T>(this T htmlInputControl, string textContent) where T : HtmlInputControl
        {
            htmlInputControl.Click();
            htmlInputControl.Value = textContent;
            htmlInputControl.FireJQueryChangeEvent();

            return htmlInputControl;
        }

        public static T AsTextAreaEnterValue<T>(this T htmlContorl, string textContent) where T : HtmlControl
        {
            htmlContorl.AssertIsVisible();
            string id = htmlContorl.GetValue<string>("id");
            string jsFormat = @"$(""#{0}"").val(""{1}"");";
            string js = string.Format(jsFormat, id, textContent);
            Manager.Current.ActiveBrowser.Actions.InvokeScript(js);
            htmlContorl.FireJQueryChangeEvent();
            htmlContorl.MouseClickCustom();

            return htmlContorl;
        }
    }
}
