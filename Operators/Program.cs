namespace Operators;

class Program
{
    static void Main(string[] args)
    {
        string[] allowedOperators = ["+", "-", "*", "/", "%"];
        try
        {
            // Collect first number
            // Verify input to be numeric
            Console.Write("Enter first number : ");
            string firstNumber = Console.ReadLine();

            while (!double.TryParse(firstNumber, out double result))
            {
                Console.WriteLine("Please enter a valid number");
                Console.Write("Enter first number : ");
                firstNumber = Console.ReadLine();
            }


            // Collect operator
            // Must be either  +,-,*,/ or %
            Console.Write("Enter operator (+,-,*,/) : ");
            string operatorSign = Console.ReadLine();
            while (!allowedOperators.Contains(operatorSign))
            {
                Console.WriteLine("Please enter a valid operator");
                Console.Write($"Enter operator {string.Join(",", allowedOperators)} : ");
                operatorSign = Console.ReadLine();
            }


            // Collect second number
            // Verify input to be numeric
            Console.Write("Enter second number : ");
            string secondNumber = Console.ReadLine();
            while (!double.TryParse(secondNumber, out double result))
            {
                Console.WriteLine("Please enter a valid number");
                Console.Write("Enter second number : ");
                secondNumber = Console.ReadLine();
            }


            // Perform calculation
            double total = operatorSign switch
            {
                "+" => double.Parse(firstNumber) + double.Parse(secondNumber),
                "-" => double.Parse(firstNumber) - double.Parse(secondNumber),
                "*" => double.Parse(firstNumber) * double.Parse(secondNumber),
                "/" => double.Parse(firstNumber) / double.Parse(secondNumber),
                "%" => double.Parse(firstNumber) % double.Parse(secondNumber),
                _ => throw new ArgumentException("Invalid operator")
            };

            Console.WriteLine($"Calculate : {firstNumber} {operatorSign} {secondNumber} = {total}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error : {e.Message}");
        }
    }
}