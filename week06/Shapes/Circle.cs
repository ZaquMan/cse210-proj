public class Circle : Shape
{
    float _radius;

    public Circle(string color, float radius) : base(color)
    {
        _radius = radius;
    }

    public override float CalculateArea()
    {
        return (float)Math.PI * _radius * _radius;
    }
}