using System;

public class Helper
{

    /// <summary>
    /// Generate a random integer.
    /// </summary>
    /// <param name="minimum">The minimum number. (Inclusive)</param>
    /// <param name="maximum">The maximum number. (Exclusive)</param>
    /// <returns>A pseudo-randomly generated integer.</returns>
    public static int GetRandomInteger(int minimum, int maximum)
    {
        Random random = new Random();
        return random.Next(minimum, maximum);
    }
}
