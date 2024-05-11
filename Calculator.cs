namespace Calculator
{
    public class Calculator
    {

        List<double> numbers = new List<double>();
        List<char> operations = new List<char>();

        public void DisplayCalculator()
        {
            Console.WriteLine("Enter numbers and operations. Press 'e' and enter to end inputs.");

            // Initial number input
            numbers.Add(GetNumber("Enter a number: "));

            char operation;
            do
            {
                operation = GetOperation("Enter an operation (+, -, *, /) or 'e' to execute: ");
                if (operation != 'e')
                {
                    operations.Add(operation);
                    numbers.Add(GetNumber("Enter a number: "));
                }
            } while (operation != 'e');

            double result = CalculateResult(numbers, operations);
            Console.WriteLine($"The result of the operations is: {result}");

        }

        static double GetNumber(string prompt)
        {
            double number;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input, please enter a valid number.");
                Console.Write(prompt);
            }
            return number;
        }

        static char GetOperation(string prompt)
        {
            Console.Write(prompt);
            char operation = Console.ReadKey().KeyChar;
            Console.WriteLine();

            while (operation != '+' && operation != '-' && operation != '*' && operation != '/' && operation != 'e')
            {
                Console.WriteLine("Invalid operation. Please enter one of the following: +, -, *, /, or 'e' to execute.");
                Console.Write(prompt);
                operation = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }

            return operation;
        }
        static double CalculateResult(List<double> numbers, List<char> operations)
        {
            double result = numbers[0];

            for (int i = 0; i < operations.Count; i++)
            {
                switch (operations[i])
                {
                    case '+':
                        result += numbers[i + 1];
                        break;
                    case '-':
                        result -= numbers[i + 1];
                        break;
                    case '*':
                        result *= numbers[i + 1];
                        break;
                    case '/':
                        if (numbers[i + 1] == 0)
                        {
                            Console.WriteLine("Error: Division by zero is not allowed.");
                            return double.NaN;
                        }
                        result /= numbers[i + 1];
                        break;
                }
            }

            return result;
        }
    }
}