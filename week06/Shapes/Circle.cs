namespace Shapes;

public class Circle : Shape
{
    private readonly double _radius;

    public Circle(string color, double radius) : base(color)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("Radius must be greater than zero.");
        }

        this._radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}