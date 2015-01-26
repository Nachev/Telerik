namespace PerformanceTest.Plugins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.WebTesting;

    public class RandomUsernamePlugin : WebTestPlugin
    {
        public string ParameterName { get; set; }

        private string addition = string.Empty;

        public string Addition
        {
            get 
            {
                if (string.IsNullOrEmpty(this.addition))
                {
                    this.addition = string.Empty;
                }

                return addition; 
            }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.addition = string.Empty;
                }
                else
                {
                    addition = value; 
                }
            }
        }

        public override void PreWebTest(object sender, PreWebTestEventArgs e)
        {
            base.PreWebTest(sender, e);

            string value = GenerateRandomString() + this.Addition;

            e.WebTest.Context.Add(this.ParameterName, value);
        }
 
        public static string GenerateRandomString()
        {
            return "cbt" + Guid.NewGuid().ToString("N").Substring(2, 22);
        }
    }
}
