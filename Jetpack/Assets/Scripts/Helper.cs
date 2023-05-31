using System;

/// <summary>
/// A general helper class used for common functions.
/// </summary>
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

    public static double GetRandomDouble(double minimum, double maximum)
    {
        Random random = new Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }
}
