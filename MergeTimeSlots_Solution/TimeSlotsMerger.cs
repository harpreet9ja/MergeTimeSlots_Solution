using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTimeSlots_Solution
{
    internal class TimeSlotsMerger
    {
        static void Main(string[] args)
        {

            List<(DateTime, DateTime)> timeSlots = new List<(DateTime, DateTime)>
            {
                (new DateTime(2024, 8, 28, 9, 0, 0), new DateTime(2024, 8, 28, 10, 0, 0)),
                (new DateTime(2024, 8, 28, 9, 30, 0), new DateTime(2024, 8, 28, 10, 30, 0)),
                (new DateTime(2024, 8, 28, 12, 0, 0), new DateTime(2024, 8, 28, 13, 0, 0)),
                (new DateTime(2024, 8, 29, 8, 30, 0), new DateTime(2024, 8, 29, 9, 30, 0))
            };

            List<(DateTime, DateTime)> mergedSlots = MergeSlots(timeSlots);
            foreach (var slot in mergedSlots)
            {
                Console.WriteLine($"({slot.Item1}, {slot.Item2})");
            }
            Console.ReadKey();
        }

        /// <summary>   
        /// Merge the overlapping or adjacent time slots
        /// Input : List of time slots
        /// Output : List of merged time slots
        static public List<(DateTime, DateTime)> MergeSlots(List<(DateTime, DateTime)> slots)
        {
            // Create a list to store the merged slots
            List<(DateTime, DateTime)> mergedSlots = new List<(DateTime, DateTime)>();

            // If the input list is empty, return an empty list
            if (slots.Count == 0)
                return mergedSlots;

            // Sort the slots by their start time in ascending order
            slots = slots.OrderBy(slot => slot.Item1).ToList();
            // Assign the first slot to the last merged slot variable
            (DateTime, DateTime) lastMerged = slots[0];
            //Add the first slot to the merged slots
            mergedSlots.Add(lastMerged);

            // Iterate through the slots starting from the second slot
            foreach (var current in slots.Skip(1))
            {
                // Check if the current slot starts before end of last merged slot or is adjacent to the last merged slot
                if (current.Item1 <= lastMerged.Item2)
                {
                    // Merge the slots
                    // Update the end time of the last merged slot if the end time of the current slot is greater
                    lastMerged = (lastMerged.Item1, lastMerged.Item2 > current.Item2 ? lastMerged.Item2 : current.Item2);
                    // Update the last slot in the merged slots list
                    mergedSlots[mergedSlots.Count - 1] = lastMerged;
                }
                else
                {
                    // If current slot doesn't overlap or is adjacent, add it to the merged slots
                    mergedSlots.Add(current);
                    // Update the last merged slot to the current slot
                    lastMerged = current;
                }
            }
            return mergedSlots;
        }
    }
}
