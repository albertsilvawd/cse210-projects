using System;

class Program
{
    static void Main()
    {
        // Testar construtores
        Fraction f1 = new Fraction(); // 1/1
        Fraction f2 = new Fraction(5); // 5/1
        Fraction f3 = new Fraction(3, 4); // 3/4
        Fraction f4 = new Fraction(1, 3); // 1/3

        // Testar Getters e Setters
        f1.SetNumerator(2);
        f1.SetDenominator(2);
        Console.WriteLine(f1.GetFractionString()); // Saída: 2/2
        Console.WriteLine(f1.GetDecimalValue());   // Saída: 1.0

        // Exibir resultados
        Console.WriteLine(f2.GetFractionString()); // 5/1
        Console.WriteLine(f2.GetDecimalValue());   // 5.0
        Console.WriteLine(f3.GetFractionString()); // 3/4
        Console.WriteLine(f3.GetDecimalValue());   // 0.75
        Console.WriteLine(f4.GetFractionString()); // 1/3
        Console.WriteLine(f4.GetDecimalValue());   // 0.3333333333333333
    }
}