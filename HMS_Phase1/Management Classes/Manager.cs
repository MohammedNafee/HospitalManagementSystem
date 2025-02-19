namespace HMS_Phase1.Management_Classes
{
    public abstract class Manager
    {
        protected HMSContext context = new HMSContext();

        internal abstract void TrackOptions(int option);
        protected abstract void Add();
        protected abstract void View();

        // Validate integer input
        internal static int ValidateInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a valid numeric ID.");
                    Console.WriteLine();
                }
            }
        }

        internal static decimal ValidateInputDecimal(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a valid decimal number.");
                    Console.WriteLine();
                }
            }
        }

        // Validate string input (ensures non-empty input)
        internal static string ValidateInputString(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a non-empty value.");
                    Console.WriteLine();
                }
            }
        }

        // Validate DateTime input
        internal static DateTime ValidateInputDate(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a valid date (e.g., YYYY-MM-DD).");
                    Console.WriteLine();
                }
            }
        }
    }
}
