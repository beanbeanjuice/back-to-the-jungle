using UnityEngine;

namespace Fish
{
    /// <summary>
    /// This class essentially holds an array of offsets.
    /// <remarks>Coded by William.</remarks>
    /// </summary>
    public class FishPattern
    {
        private Vector2[] _offsets;

        /// <summary>
        /// Gets the amount of fish in this pattern.
        /// </summary>
        /// <returns>The fish amount.</returns>
        public int GetFishCount()
        {
            return this._offsets.Length;
        }

        /// <summary>
        /// Gets the list of offsets for this pattern.
        /// </summary>
        /// <returns>A list of offsets.</returns>
        public Vector2[] GetLocationOffsets()
        {
            return this._offsets;
        }

        /// <summary>
        /// Set the fish offsets.
        /// </summary>
        /// <param name="newOffsets">The new fish offsets to set to.</param>
        public void SetOffsets(Vector2[] newOffsets)
        {
            this._offsets = newOffsets;
        }
    }
}
