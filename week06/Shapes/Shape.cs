public abstract class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public abstract float CalculateArea();

    public void SetColor(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }
}
