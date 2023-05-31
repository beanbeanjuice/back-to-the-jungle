using System;
using System.Collections.Generic;
using System.ComponentModel;
using Player;
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
        [SerializeField] private GameObject player;
        [SerializeField] private float minXFromPlayer;
        [SerializeField] private float maxXFromPlayer;
        [SerializeField] private float minY;
        [SerializeField] private float maxY;
        [SerializeField] private float delay;

        private FishPatterns _fishPatterns;
        private int _numPatterns;

        private bool hasGenerated = false;

        public void Start()
        {
            this._fishPatterns = new FishPatterns();
            this._numPatterns = this._fishPatterns.GetPatterns().Count;
        }

        /// <summary>
        /// Build and spawn the fish in.
        /// </summary>
        /// <param name="initialFishSpec">The given fish spec.</param>
        public void Build(FishSpec initialFishSpec)
        {
            Vector3 initialLocation = initialFishSpec.GetLocation();
            // TODO: Choose an appropriate pattern based on initial fish X and Y.
            FishPatterns.FishPattern pattern = this._fishPatterns.GetPatterns()[Helper.GetRandomInteger(0, this._numPatterns)];

            foreach (FishSpec fishSpec in PopulateFishSpecs(initialFishSpec, pattern))
            {
                GameObject fish = Instantiate(this.fishPrefab, fishSpec.GetLocation(), Quaternion.identity);
                fish.GetComponent<FishController>().ChangeType(fishSpec.GetFishType());
            }

        }

        private void Update()
        {
            if (!this.hasGenerated)
            {
                FishSpec spec = GenerateRandomFish();
                Build(spec);
                this.hasGenerated = true;
            }
        }

        private List<FishSpec> PopulateFishSpecs(FishSpec initialSpec, FishPatterns.FishPattern pattern)
        {
            List<FishSpec> fishes = new List<FishSpec>();
            Vector3 currentLocation = initialSpec.GetLocation();
            fishes.Add(initialSpec);

            for (int i = 0; i < pattern.GetFishCount()-1; i++)
            {
                FishSpec spec = GenerateRandomFish();
                currentLocation += pattern.GetLocationOffset();
                spec.SetLocation(currentLocation);
                fishes.Add(spec);
            }

            return fishes;
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
            float fishX = (float)Helper.GetRandomDouble(this.minXFromPlayer, this.maxXFromPlayer) + this.player.transform.position.x;
            float fishY = (float)Helper.GetRandomDouble(this.minY, this.maxY);

            Vector3 location = new Vector3(fishX, fishY, this.fishPrefab.transform.position.z);
            return new FishSpec(type, location);
        }
    }
}
