public class Circle : Shape
{
    private float radius;

    public Circle(string color, float radius) : base(color)
    {
        this.radius = radius;
    }

    public override float GetArea()
    {
        return (float)(Math.PI * radius * radius); // Área do círculo
    }
}
