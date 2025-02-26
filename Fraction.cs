namespace Frac;

class Fraction
{   
    protected int numerator = 1, denominator = 1;
    protected int floor = 0, fraction =0;

    public Fraction(){}
    public Fraction(int a, int b)
    {
        try
        {
            if (b != 0) 
            {
                this.numerator = a;
                this.denominator = b; 
                this.floor = this.numerator / this.denominator;
                this.fraction = this.numerator % this.denominator;
            }
            else throw new Exception($"The denominator must be not equal to 0");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
    }
    public int getFloor(){
        return this.floor;
    }
    public int getNumerator()
    {
        return this.numerator;
    }
    public int getDenominator()
    {
        return this.denominator;
    }
    public void simplifying()
    {
        int m = this.numerator, n = this.denominator, r = m % n;
        while( r != 0 )
        {
            m = n;
            n = r;
            r = m % n;
        }
        this.numerator/=n;
        this.denominator/=n;
    }
    public static Fraction operator + (Fraction f1, Fraction f2)
    {
        Fraction f;
        if (f1.denominator != f2.denominator)
            f = new Fraction (f1.numerator * f2.denominator + f2.numerator * f1.denominator, f1.denominator * f2.denominator);
        else f = new Fraction (f1.numerator + f2.numerator, f1.denominator);
        return f;
    }
    public static Fraction operator - (Fraction f1, Fraction f2)
    {
        Fraction f;
        if (f1.denominator != f2.denominator)
            f = new Fraction (f1.numerator * f2.denominator - f2.numerator * f1.denominator, f1.denominator * f2.denominator);
        else f = new Fraction (f1.numerator - f2.numerator, f1.denominator);
        return f;
    }
    public static Fraction operator * (Fraction f1, Fraction f2)
    {
        return new Fraction (f1.numerator * f2.numerator, f1.denominator * f2.denominator);
    }
    public static Fraction operator / (Fraction f1, Fraction f2)
    {
        return new Fraction (f1.numerator * f2.denominator, f1.denominator * f2.numerator);
    }
};

