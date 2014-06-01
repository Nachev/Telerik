namespace MobilePhone
{
    using System.Text;

    public class Display
    {
        private const double DEFAULT_DIAGONAL = 4.3;
        private const int DEFAULT_NUMBER_OF_COLORS = 16000000;

        public Display(double? screenDiagonal = null, int? numberOfColors = null)
        {
            this.ScreenDiagonal = screenDiagonal;
            this.NumberOfColors = numberOfColors;
        }

        public Display()
            : this(DEFAULT_DIAGONAL, DEFAULT_NUMBER_OF_COLORS)
        {
        }

        private double? ScreenDiagonal { get; set; }

        private int? NumberOfColors { get; set; }

        public override string ToString()
        {
            StringBuilder tostr = new StringBuilder();
            if (this.ScreenDiagonal != null)
            {
                tostr.Append("Screen diagonal: ");
                tostr.Append(this.ScreenDiagonal);
                tostr.Append(" ");
            }

            if (this.NumberOfColors != null)
            {
                tostr.Append("Screen colors count: ");
                tostr.Append(this.NumberOfColors);
                tostr.Append(" ");
            }

            return tostr.ToString();
        }
    }
}
