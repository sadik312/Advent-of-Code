using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AocDay1
{
    public class Program
    {
        static void Main(String[] args)
        {
            // Lists for store the locations from each column
            List<int> List1 = new List<int>();
            List<int> List2 = new List<int>();
            
            // Read all lines from the input file
           string[] lines = File.ReadAllLines("input.txt"); 
           
           foreach (string line in lines)
               {
                // split the line by whitespace
                string[] parts = line.Split(new[] { ' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
                
                if(parts.Length == 2)
                    {
                        // parse the number and add to respective list
                        List1.Add(int.Parse(parts[0]));
                        List2.Add(int.Parse(parts[1]));
                    }
               }

            // Sort the lists from smallest to largest value
           List1.Sort();
           List2.Sort();
           
           // List to store the differences
           List<int> differences = new List<int>();

           // calculate differences
           for (int i = 0; i < List1.Count; i++)
               {
                differences.Add(Math.Abs((List1[i] - List2[i])));
               }
           //Console.WriteLine("differences: " + string.Join(" ", differences));
           
           // get sum of differences
           int total = differences.Sum();
           Console.WriteLine(total);

           // print lists to verify
           // Console.WriteLine("List1: " + string.Join(", ", List1));
           // Console.WriteLine("List2: " + string.Join(", ", List2));
        }
    }
}