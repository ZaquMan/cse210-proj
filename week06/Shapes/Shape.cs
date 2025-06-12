public abstract class Shape
{
    string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public abstract float CalculateArea();
}
