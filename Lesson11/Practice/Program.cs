using System.Runtime.InteropServices;

public delegate double MathOperation(double x, double y);

class Program
{
    public static double Add(double x, double y)
    {
        return x + y;
    }

    public static double Multiply(double x, double y)
    {
        return x * y;
    }

    public static double ExecuteOperation(MathOperation operation, double x, double y)
    {
        return operation(x, y);
    }

    public static void Main()
    {
        MathOperation handler = Multiply;
        double i = ExecuteOperation(handler, 5, 5);
        Console.WriteLine(i);
        handler = Add;
        i = ExecuteOperation(handler, 5, 5);
        Console.WriteLine(i);
    }
}