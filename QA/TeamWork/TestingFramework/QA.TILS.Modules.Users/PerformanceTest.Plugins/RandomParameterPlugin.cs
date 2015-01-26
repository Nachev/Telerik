namespace QA.TILS.Modules.Users.Tests.PerformanceAndLoad.Front.Registration
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.WebTesting;

    public class RandomParameterPlugin : WebTestRequestPlugin
    {
        private string additionToValue = string.Empty;

        public string ParameterName
        {
            get;
            set;
        }

        public string AdditionToValue
        {
            get
            {
                if (string.IsNullOrEmpty(this.additionToValue))
                {
                    additionToValue = string.Empty;
                }

                return this.additionToValue;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.additionToValue = string.Empty;
                }
                else
                {
                    this.additionToValue = value;
                }
            }
        }

        public override void PreRequest(object sender, PreRequestEventArgs e)
        {
            base.PreRequest(sender, e);

            string value = "cbt" + Guid.NewGuid().ToString("N").Substring(2, 28) + AdditionToValue;
            e.WebTest.Context.Add(ParameterName, value);
        }
    }
}
