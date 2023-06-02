using UnityEngine;

namespace Fish.Patterns
{
    /// <summary>
    /// A class that contains Vectors for the patterns
    /// at which the fish should spawn. This class essentially
    /// holds patterns which holds offsets of vectors.
    /// <remarks>Coded by William</remarks>
    /// </summary>
    [CreateAssetMenu]
    public class FishPatterns : ScriptableObject
    {
        [SerializeField] private FishPattern[] fishPatterns;

        /// <summary>
        /// Get all of the fish patterns.
        /// </summary>
        /// <returns>An array of fish patterns.</returns>
        public FishPattern[] GetPatterns()
        {
            return this.fishPatterns;
        }
    }
}
