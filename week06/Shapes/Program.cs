using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        // Adicionar formas à lista
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));

        // Exibir a cor e a área de cada forma
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()} - Area: {shape.GetArea()}");
        }
    }
}
