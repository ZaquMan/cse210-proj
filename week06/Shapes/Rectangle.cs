public class Rectangle : Shape
{
    float _sideX;
    float _sideY;

    public Rectangle(string color, float sideX, float sideY) : base(color)
    {
        _sideX = sideX;
        _sideY = sideY;
    }

    public override float CalculateArea()
    {
        return _sideX * _sideY;
    }
}