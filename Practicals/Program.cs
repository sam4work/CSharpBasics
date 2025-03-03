using System;
using System.Globalization;

namespace Practicals
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                // Prompt for the first number
                Console.Write("Enter the first number: ");
                string firstInput = Console.ReadLine();
                if (!double.TryParse(firstInput, NumberStyles.Float, CultureInfo.InvariantCulture, out double firstNumber))
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.");
                    continue;
                }

                // Prompt for the operator
                Console.Write("Enter an operator (+, -, *, /): ");
                string operation = Console.ReadLine();

                // Validate the operator
                if (operation != "+" && operation != "-" && operation != "*" && operation != "/")
                {
                    Console.WriteLine("Invalid operator. Please enter one of the following: +, -, *, /.");
                    continue;
                }

                // Prompt for the second number
                Console.Write("Enter the second number: ");
                string secondInput = Console.ReadLine();
                if (!double.TryParse(secondInput, NumberStyles.Float, CultureInfo.InvariantCulture, out double secondNumber))
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.");
                    continue;
                }

                // Perform the calculation
                try
                {
                    double result = operation switch
                    {
                        "+" => firstNumber + secondNumber,
                        "-" => firstNumber - secondNumber,
                        "*" => firstNumber * secondNumber,
                        "/" => secondNumber != 0 ? firstNumber / secondNumber : throw new DivideByZeroException(),
                        _ => throw new InvalidOperationException("Unexpected operator.")
                    };

                    // Display the result
                    Console.WriteLine($"Result: {firstNumber} {operation} {secondNumber} = {result}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                // Ask the user if they want to perform another calculation
                Console.Write("Would you like to perform another calculation? (y/n): ");
                string continueResponse = Console.ReadLine();
                if (continueResponse?.ToLower() != "y")
                {
                    break;
                }
            }
        }
    }
}
