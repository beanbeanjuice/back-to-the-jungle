using UnityEngine;

namespace Fish.Patterns
{
    /// <summary>
    /// This class essentially holds an array of offsets.
    /// <remarks>Coded by William</remarks>
    /// </summary>
    [CreateAssetMenu]
    public class FishPattern : ScriptableObject
    {
        [SerializeField] private Vector2[] offsets;

        /// <summary>
        /// Gets the amount of fish in this pattern.
        /// </summary>
        /// <returns>The fish amount.</returns>
        public int GetFishCount()
        {
            return this.offsets.Length;
        }

        /// <summary>
        /// Gets the list of offsets for this pattern.
        /// </summary>
        /// <returns>A list of offsets.</returns>
        public Vector2[] GetLocationOffsets()
        {
            return this.offsets;
        }
    }
}
