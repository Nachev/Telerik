namespace QA.Framework.Core.Extensions
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using System.Threading;

    public static class HtmlControlsJQueryEvents
    {
        public static T FireJQueryChangeEvent<T>(this T htmlControl) where T : HtmlControl
        {
            htmlControl.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.change);

            return htmlControl;
        }

        public static T FireJQueryClickEvent<T>(this T htmlControl) where T : HtmlControl
        {
            htmlControl.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.click);

            return htmlControl;
        }

        public static T FireJQueryDoubleClickEvent<T>(this T htmlControl) where T : HtmlControl
        {
            htmlControl.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.dblclick);
            Thread.Sleep(500);

            return htmlControl;
        }

        public static T FireJQueryFocusEvent<T>(this T htmlControl) where T : HtmlControl
        {
            htmlControl.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.focus);
            Thread.Sleep(500);

            return htmlControl;
        }

        public static T FireJQueryHoverEvent<T>(this T htmlControl) where T : HtmlControl
        {
            htmlControl.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.hover);
            Thread.Sleep(500);

            return htmlControl;
        }

        public static T FireJQueryKeyUpEvent<T>(this T htmlControl) where T : HtmlControl
        {
            htmlControl.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.keyup);
            Thread.Sleep(500);

            return htmlControl;
        }

        public static T FireJQueryMouseUpEvent<T>(this T htmlControl) where T : HtmlControl
        {
            htmlControl.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.mouseup);
            Thread.Sleep(500);

            return htmlControl;
        }

        public static T FireJQueryKeyPressEvent<T>(this T htmlControl) where T : HtmlControl
        {
            htmlControl.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.keypress);
            Thread.Sleep(500);

            return htmlControl;
        }

        public static T FireJQueryBlurEvent<T>(this T htmlControl) where T : HtmlControl
        {
            htmlControl.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.blur);
            Thread.Sleep(500);

            return htmlControl;
        }
    }
}
