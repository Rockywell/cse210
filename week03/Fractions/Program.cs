using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");


        Fraction defaultFraction = new Fraction();
        Fraction wholeFraction = new Fraction(5);
        Fraction fractionOne = new Fraction(3, 4);
        Fraction fractionTwo = new Fraction(1, 3);

        List<Fraction> fractionList = [defaultFraction, wholeFraction, fractionOne, fractionTwo];

        foreach (Fraction fraction in fractionList)
        {
            Console.WriteLine($"Fraction: {fraction.GetFractionString()}, Decimal: {fraction.GetDecimalValue()}");
        }
    }
}