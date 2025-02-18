
namespace HMS_Phase1.Management_Classes
{
    public abstract class Manager
    {
        protected HMSContext context = new HMSContext();

        internal abstract void TrackOptions(string option);
        protected abstract void View();

        public static int ValidateInput()
        {
            while (true)
            {
                Console.WriteLine("Enter ID: ");

                // Using int.TryParse() instead of int.Parse()
                // to avoid exceptions if the user enters a non-numeric value.
                // int.TryParse() safely attempts to convert the input to an integer
                // and returns true if successful.
                if (int.TryParse(Console.ReadLine(), out int Id))
                {
                    return Id;
                }
                else
                {
                    Console.WriteLine("Invalid Input! Please enter a valid numeric ID.");
                    Console.WriteLine();
                }
            }
        }

    }
}
