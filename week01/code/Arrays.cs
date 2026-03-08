public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array of doubles with the size equal to length
        // Step 2: Use a loop that goes from index 0 to length - 1
        // Step 3: For each index calculate the multiple of the number
        // Step 4: Store the result in the array at the current index
        // Step 5: Return the filled array

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Determine where to split the list by subtracting amount from the total count
        // Step 2: Get the last 'amount' elements using GetRange
        // Step 3: Get the remaining elements at the beginning of the list
        // Step 4: Clear the original list
        // Step 5: Add the last part first, then add the first part to complete the rotation

        int splitIndex = data.Count - amount;

        List<int> lastPart = data.GetRange(splitIndex, amount);
        List<int> firstPart = data.GetRange(0, splitIndex);

        data.Clear();

        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}