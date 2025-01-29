using System;

namespace DiceRollingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the dice throwing simulator!");
            Console.Write("How many dice rolls would you like to simulate? ");
            int numberOfRolls; // Receive the user input

            // Validate user input
            while (!int.TryParse(Console.ReadLine(), out numberOfRolls) || numberOfRolls <= 0)
            {
                Console.Write("Please enter a valid positive integer: "); 
                // Does not allow user to input a negative number
            }

            // Create an instance of DiceRoller class and simulate the rolls
            DiceRoller roller = new DiceRoller();
            int[] results = roller.SimulateRolls(numberOfRolls);

            // Display the results
            Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            Console.WriteLine($"Total number of rolls = {numberOfRolls}.\n");

            for (int i = 2; i <= 12; i++)
            {
                int percentage = (int)Math.Round((double)results[i] / numberOfRolls * 100);
                Console.WriteLine($"{i}: {new string('*', percentage)}");
                // calculate the percentage of each value rolled
            }

            Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
        }
    }

    class DiceRoller
    {
        private Random random = new Random();

        public int[] SimulateRolls(int numberOfRolls)
        {
            int[] rollCounts = new int[13]; // Indices 0 and 1 will not be used

            for (int i = 0; i < numberOfRolls; i++)
            {
                int roll1 = random.Next(1, 7); // Roll the first die
                int roll2 = random.Next(1, 7); // Roll the second die
                int sum = roll1 + roll2; // Add the sum of both dice together

                rollCounts[sum]++; // Store and increment
            }

            return rollCounts;
        }
    }
}
