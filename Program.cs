// See https://aka.ms/new-console-template for more information

using Static;
using Frac; 

int a = 1 , b = 4;
Fraction f1 = new Fraction(1, 4);
Fraction f2 = new Fraction(1, 6);
f1 = f1 - f2;

Console.Write(f1.getNumerator());
Console.Write('/');
Console.Write(f1.getDenominator());
Console.WriteLine();
f1.simplifying();
Console.Write(f1.getNumerator());
Console.Write('/');
Console.Write(f1.getDenominator());
// DRV drv  = new DRV();

// // drv.inputDRV();
// double[,] arr = new double [2, 6] { { 1, 2, 3, 4, 5, 6 }, { 0.1666, 0.1666, 0.1666, 0.1666, 0.1666, 0.1666} };

// drv.setDRV(6, arr);

// double ev = drv.ExpectedValue();
// double v = drv.Variance();
// Console.WriteLine(ev);
// Console.WriteLine(v);