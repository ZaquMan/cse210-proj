using System;
using System.Reflection.Metadata;

public class Fraction
{
    //Attributes
    private int _numerator;
    private int _denominator;

    //Constructors
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    //Methods - Setter/Getter
    public int GetTop()
    {
        return _numerator;
    }

    public void SetTop(int numerator)
    {
        _numerator = numerator;
    }

    public int GetBottom()
    {
        return _denominator;
    }

    public void SetBottom(int denominator)
    {
        _denominator = denominator;
    }

    //Methods - Other
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}