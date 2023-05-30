using System;
using System.ComponentModel;
using UnityEngine;

namespace Fish
{
    /// <summary>
    /// The fish factory. This class is used for generating
    /// and spawning fish in.
    /// </summary>
    public class FishFactory : MonoBehaviour
    {
        [SerializeField] private GameObject fishPrefab;

        /// <summary>
        /// Build and spawn the fish in.
        /// </summary>
        /// <param name="fishSpec">The given fish spec.</param>
        public void Build(FishSpec fishSpec)
        {
            GameObject fish = Instantiate(this.fishPrefab, fishSpec.GetLocation(), Quaternion.identity);
            fish.GetComponent<FishController>().ChangeType(fishSpec.GetFishType());
        }

        /// <summary>
        /// Generate a pseudo-random fish spec.
        /// </summary>
        /// <returns>A pseudo-random fish spec.</returns>
        /// <exception cref="InvalidEnumArgumentException">Thrown if the generated enum type is not listed.</exception>
        public FishSpec GenerateRandomFish()
        {
            FishType randomType = Helper.GetRandomInteger(0, Enum.GetNames(typeof(FishType)).Length) switch
            {
                0 => FishType.RED,
                1 => FishType.PURPLE,
                2 => FishType.PINK,
                3 => FishType.ORANGE,
                4 => FishType.GREEN,
                5 => FishType.CORAL,
                6 => FishType.BLUE,
                7 => FishType.BEIGE,
                _ => throw new InvalidEnumArgumentException("Enum type missing.")
            };

            return GenerateRandomFish(randomType);
        }

        /// <summary>
        /// Generate a pseudo-random fish spec.
        /// </summary>
        /// <param name="type">A pre-determined fish type.</param>
        /// <returns>A pseudo-random fish spec.</returns>
        public FishSpec GenerateRandomFish(FishType type)
        {
            // TODO: Generate random location for the fish according to game logic.
            Vector2 location = new Vector2(0, 0);
            return new FishSpec(type, location);
        }
    }
}
