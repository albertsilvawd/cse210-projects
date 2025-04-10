public class Rectangle : Shape
{
    private float width;
    private float height;

    public Rectangle(string color, float width, float height) : base(color)
    {
        this.width = width;
        this.height = height;
    }

    public override float GetArea()
    {
        return width * height; // Área do retângulo
    }
}
