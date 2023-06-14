using System;

/// <summary>
/// A general helper class used for common functions.
/// <remarks>Coded by William.</remarks>
/// </summary>
public static class Helper
{
    /// <summary>
    /// Generate a pseudo-random integer.
    /// </summary>
    /// <param name="minimum">The minimum number. (Inclusive)</param>
    /// <param name="maximum">The maximum number. (Exclusive)</param>
    /// <returns>A pseudo-randomly generated integer.</returns>
    public static int GetRandomInteger(int minimum, int maximum)
    {
        Random random = new Random();
        return random.Next(minimum, maximum);
    }

    /// <summary>
    /// Get a pseudo-random double.
    /// </summary>
    /// <param name="minimum">The minimum number.</param>
    /// <param name="maximum">The maximum number.</param>
    /// <returns></returns>
    public static double GetRandomDouble(double minimum, double maximum)
    {
        Random random = new Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }
}
