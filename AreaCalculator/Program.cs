namespace Program;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the length of Rectangle: ");
        double l = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the width of Rectangele: ");
        double w = Convert.ToDouble(Console.ReadLine());
        double area = w * l;
        Console.WriteLine("Area of Rectangle: " + area);
    }
}
