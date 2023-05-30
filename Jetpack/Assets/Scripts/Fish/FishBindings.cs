using System.ComponentModel;
using UnityEngine;

namespace Fish
{
    /// <summary>
    /// A class containing the possible bindings of the fish.
    /// </summary>
    [CreateAssetMenu]
    public class FishBindings : ScriptableObject
    {
        [System.Serializable]
        private class FishTypeEntry
        {
            [SerializeField] private FishType type;
            [SerializeField] private Sprite sprite;

            /// <summary>
            /// Get the type of the fish.
            /// </summary>
            /// <returns>The fish type.</returns>
            public FishType GetFishType()
            {
                return this.type;
            }

            /// <summary>
            /// The sprite for the specified fish color.
            /// </summary>
            /// <returns>The fish sprite.</returns>
            public Sprite GetSprite()
            {
                return this.sprite;
            }
        }

        [SerializeField] private FishTypeEntry[] fishTypes;

        /// <summary>
        /// Get the sprite for the given fish type.
        /// </summary>
        /// <param name="type">The type of fish.</param>
        /// <returns>The specified sprite.</returns>
        /// <exception cref="InvalidEnumArgumentException">Thrown if the fish color asset is not set correctly.</exception>
        public Sprite GetFishSprite(FishType type)
        {
            foreach (FishTypeEntry fishTypeEntry in this.fishTypes)
                if (fishTypeEntry.GetFishType() == type) return fishTypeEntry.GetSprite();

            throw new InvalidEnumArgumentException("Invalid color passed. Color does not exist in list.");
        }
    }
}
