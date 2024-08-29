<h1>Folder: MergeTimeSlots_Solution, File --> TimeSlotsMerger.cs </h1> 
  - Contains the logic of merging overlapping/adjacent timeslots

<H2>High Level  Logic</H2>
The main goal of the program is to merge multiple overlapping or adjacent time slots into single slots.
The program uses the MergeSlots method to accomplish this.

<H3>Inside the MergeSlots Method:</H3>
Input: The method takes a list of time slots as input.
Output: It returns a new list of merged time slots.

<h4>Step 1</h4>
If the input list of time slots is empty, the method returns an empty list.
<h4>Step 2</h4>
The time slots are sorted by their start times & date in ascending order. 
<h4>Step 3</h4>
The first time slot is picked as the initial "last merged slot" and added to the list of merged slots.
<h4>Step 4</h4>
The program then iterates over the remaining time slots. For each time slot
  <ul>
    Check for Overlap or Adjacency
    <li>If the current time slot starts before the end of the last merged slot or immediately after it, they are considered overlapping or adjacent</li>
    <li>The program merges these two slots by updating the end time of the last merged slot to the later end time between the two slots</li>
    </ul>
<ul>No Overlap:
    <li>If the current slot does not overlap or is not adjacent to the last merged slot, it is added as a new entry in the list of merged slots.</li>
    <li>The program then updates the "last merged slot" to the current slot.</li>
  </ul>
Finally returns the merged slots 

<h4>Step 5</h4>
Back in the Main method, the merged slots are printed out one by one using a foreach loop.
