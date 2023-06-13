using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace Fish
{
    /// <summary>
    /// The fish factory. This class is used for generating
    /// and spawning fish in.
    /// <remarks>Coded by William.</remarks>
    /// </summary>
    public class FishFactory : MonoBehaviour
    {
        [SerializeField] private GameObject fishPrefab;
        [SerializeField] private GameObject player;
        [SerializeField] private float xDistanceFromPlayer;
        [SerializeField] private float minY;
        [SerializeField] private float maxY;
        [SerializeField] private float minDelay;
        [SerializeField] private float maxDelay;
        [SerializeField] private float spacingScale = 1.0f;

        private FishPatternsAsset _fishPatterns;
        private int _numPatterns;
        private float _delay;
        private float _delayTimer;

        private void Awake()
        {
            this._fishPatterns = UnityEngine.Resources.Load("Patterns/Fish/fish_patterns_asset") as FishPatternsAsset;

            if (null == this._fishPatterns) throw new NullReferenceException("Fish patterns is null...");

            this._numPatterns = this._fishPatterns.fishPatterns.Length;
        }

        /// <summary>
        /// Build and spawn the fish in.
        /// </summary>
        /// <param name="initialFishSpec">The given fish spec.</param>
        private void Build(FishSpec initialFishSpec)
        {
            FishPattern pattern = this._fishPatterns.fishPatterns[Helper.GetRandomInteger(0, this._numPatterns)];

            // Spawn all of the fish specs into the scene.
            foreach (FishSpec fishSpec in PopulateFishSpecs(initialFishSpec, pattern))
            {
                GameObject fish = Instantiate(this.fishPrefab, fishSpec.GetLocation(), Quaternion.identity);
                fish.GetComponent<FishController>().ChangeType(fishSpec.GetFishType());
            }

        }

        private void Update()
        {
            this._delayTimer += Time.deltaTime;

            if (!(this._delayTimer >= this._delay)) return;

            Build(GenerateRandomFish());
            this._delayTimer = 0;
            this._delay = (float)Helper.GetRandomDouble(this.minDelay, this.maxDelay);
        }

        private List<FishSpec> PopulateFishSpecs(FishSpec initialSpec, FishPattern pattern)
        {
            List<FishSpec> fishes = new List<FishSpec>();
            Vector3 initialLocation = initialSpec.GetLocation();
            fishes.Add(initialSpec);

            // Skip the 0th index. Already done above.
            for (int i = 1; i < pattern.GetFishCount(); i++)
            {
                FishSpec spec = GenerateRandomFish();
                spec.SetLocation(initialLocation + ((Vector3)pattern.GetLocationOffsets()[i] * this.spacingScale));
                fishes.Add(spec);
            }

            if (CheckFishSpecs(fishes)) return fishes;

            /*
             * If the fish specs are not allowed, we need to completely regenerate them.
             * However, we don't change the pattern. This is so that a single pattern
             * won't just not show up because of its shape.
             */
            FishSpec newSpec = GenerateRandomFish();
            return PopulateFishSpecs(newSpec, pattern);  // TODO: Possibly improve this. Recursive call.
        }

        private bool CheckFishSpecs(IEnumerable<FishSpec> specs)
        {
            return specs.All(spec => !(spec.GetLocation().y > this.maxY) && !(spec.GetLocation().y < this.minY));
        }

        /// <summary>
        /// Generate a pseudo-random fish spec.
        /// </summary>
        /// <returns>A pseudo-random fish spec.</returns>
        /// <exception cref="InvalidEnumArgumentException">Thrown if the generated enum type is not listed.</exception>
        private FishSpec GenerateRandomFish()
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
        private FishSpec GenerateRandomFish(FishType type)
        {
            float fishX = this.xDistanceFromPlayer + this.player.transform.position.x;
            float fishY = (float)Helper.GetRandomDouble(this.minY, this.maxY);

            Vector3 location = new Vector3(fishX, fishY, this.fishPrefab.transform.position.z);
            return new FishSpec(type, location);
        }
    }
}
