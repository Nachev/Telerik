namespace TestFramework.Core.Extensions
{
    using ArtOfTest.Common.UnitTesting;
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public static class HtmlControlsAssertions
    {
        public const string TextNotAsExpectedExceptionMessage = "Control inner text mismatch\n Expected: {0} \n Actual: {1}";

        public static T AssertTextIsContained<T>(this T control, string expectedText) where T : HtmlControl
        {
            string realText = control.BaseElement.InnerText;
            string exceptionMessage = string.Format(TextNotAsExpectedExceptionMessage, expectedText, realText);

            Assert.IsTrue(realText.Contains(expectedText), exceptionMessage);

            return control;
        }

        public static T AssertTextEquals<T>(this T control, string expectedText) where T : HtmlControl
        {
            string realText = control.BaseElement.InnerText;
            string exceptionMessage = string.Format(TextNotAsExpectedExceptionMessage, expectedText, realText);

            Assert.AreEqual<string>(expectedText, realText, exceptionMessage);

            return control;
        }

        public static T AssertValueEquals<T>(this T control, string expectedValue) where T : HtmlControl
        {
            string realVlue = control.GetValue<string>("value", "0");
            string exceptionMessage = string.Format("Control value mismatch\n Expected: {0} \n Actual: {1}", expectedValue, realVlue);

            Assert.AreEqual<string>(expectedValue, realVlue, exceptionMessage);

            return control;
        }

        public static T AssertIsPresent<T>(this T control) where T : HtmlControl
        {
            string exceptionMessage = string.Concat("The '", control.TagName, "' is not present on the page but it should be");
            Assert.IsNotNull(control, exceptionMessage);
            exceptionMessage = string.Concat("The '", control.TagName, "' is not visible on the page but it should be");
            Assert.IsTrue(control.IsVisible(), exceptionMessage);

            return control;
        }

        public static T AssertIsNotVisible<T>(this T control) where T : HtmlControl
        {
            string exceptionMessage = string.Concat("The '", control.TagName, "' is visible on the page but it should not be");
            Assert.IsFalse(control.IsVisible(), exceptionMessage);

            return control;
        }
    }
}