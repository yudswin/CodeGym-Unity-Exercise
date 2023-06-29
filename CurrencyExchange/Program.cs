namespace Program;

class Program {
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter value to exchange (1 USD = 23000 VND): ");
        double valueUSD = Convert.ToDouble(Console.ReadLine());
        double valueVND = valueUSD * 23000;
        Console.WriteLine(valueUSD + " USD = " + valueVND + " VND.");
    }
}