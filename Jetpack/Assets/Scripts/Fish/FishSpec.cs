using UnityEngine;

namespace Fish
{
    /// <summary>
    /// A class containing the fish specifications.
    /// <remarks>Coded by William</remarks>
    /// </summary>
    public class FishSpec
    {
        private readonly FishType _type;
        private Vector3 _location;

        /// <summary>
        /// Create a FishSpec object.
        /// </summary>
        /// <param name="type">The type of the fish.</param>
        /// <param name="location">The location the fish should spawn.</param>
        public FishSpec(FishType type, Vector3 location)
        {
            this._type = type;
            this._location = location;
        }

        /// <summary>
        /// Get the fish type.
        /// </summary>
        /// <returns>The fish type.</returns>
        public FishType GetFishType()
        {
            return this._type;
        }

        /// <summary>
        /// Get the fish spawn location.
        /// </summary>
        /// <returns>The spawn location.</returns>
        public Vector3 GetLocation()
        {
            return this._location;
        }

        /// <summary>
        /// Set this fish spec to a new location.
        /// </summary>
        /// <param name="location">The new location.</param>
        public void SetLocation(Vector3 location)
        {
            this._location = location;
        }
    }
}
