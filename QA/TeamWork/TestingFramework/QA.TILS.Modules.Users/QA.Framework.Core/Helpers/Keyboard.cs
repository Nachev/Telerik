namespace QA.Framework.Core.Helpers
{
    using ArtOfTest.WebAii.Core;
    using System.Windows.Forms;

    public static class Keyboard
    {
        public static void PressKey(Keys key)
        {
            Manager.Current.Desktop.KeyBoard.KeyPress(key);
        }

        public static void PressKey(Keys key, int numberOfTimes)
        {
            for (int i = 0; i < numberOfTimes; i++)
            {
                PressKey(key);
            }
        }

        public static void DeleteFocusedFieldTextContent()
        {
            SendKeys.SendWait("^A");
            PressKey(Keys.Delete);
        }
    }
}
