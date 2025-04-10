public class Square : Shape
{
    private float side;

    public Square(string color, float side) : base(color)
    {
        this.side = side;
    }

    public override float GetArea()
    {
        return side * side; // Área do quadrado
    }
}
