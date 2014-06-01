using System;

class MathExpression
{
    static void Main()
    {
        decimal varN = decimal.Parse(Console.ReadLine());
        decimal varM = decimal.Parse(Console.ReadLine());
        decimal varP = decimal.Parse(Console.ReadLine());
        const int numeratorConst = 1337;
        const decimal denumeratorConst = 128.523123123M;
        decimal numerator = ((varN * varN) + (1 / (varM * varP)) + numeratorConst);
        decimal denumerator = (varN - denumeratorConst * varP);
        double sin = (int)varM % 180;
        decimal addition = (decimal)Math.Sin(sin);
        //numerator = ((varN * varN) + (1 / (varM * varP)) + numeratorConst);
        //denumerator = (varN - denumeratorConst * varP);
        //double sin = new double();
        //sin = varM % 180;
        //multiplier = Math.Sin(sin);
        //double result = new double();
        decimal result = (numerator / denumerator) + addition;
        Console.Write("{0:0.000000}", result);
    }
}
