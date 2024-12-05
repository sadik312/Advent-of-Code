using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AocDay2
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Read all lines from the input file
            string[] lines = File.ReadAllLines("../input.txt");

            // Parse the reports into a list of lists
            List<List<int>> reports = lines
                .Select(line => line.Split(' ').Select(int.Parse).ToList())
                .ToList();

            // Count the safe reports
            int safeCount = reports.Count(IsSafeReport);

            // Output the result
            Console.WriteLine($"Number of safe reports: {safeCount}");
        }

        // Function to check if a report is safe
        static bool IsSafeReport(List<int> levels)
        {
            // Check if levels are either all increasing or all decreasing
            bool increasing = true;
            bool decreasing = true;

            for (int i = 1; i < levels.Count; i++)
            {
                int diff = levels[i] - levels[i - 1];

                // Check the difference is between 1 and 3
                if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                {
                    return false;
                }

                // Determine the direction
                if (diff < 0) increasing = false;
                if (diff > 0) decreasing = false;
            }

            // A report is safe if it is strictly increasing or decreasing
            return increasing || decreasing;
        }
    }
}
