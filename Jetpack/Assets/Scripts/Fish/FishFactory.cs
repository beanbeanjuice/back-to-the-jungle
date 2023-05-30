using System;
using System.ComponentModel;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Fish
{
    public class FishFactory : MonoBehaviour
    {

        [SerializeField] private GameObject fishPrefab;

        public void Start()
        {
            FishSpec spec = GenerateRandomFish(FishType.PINK);
            Build(spec);
        }

        public void Build(FishSpec fishSpec)
        {
            GameObject fish = Instantiate(this.fishPrefab, fishSpec.getLocation(), Quaternion.identity);
            fish.GetComponent<FishController>().ChangeType(fishSpec.getFishType());
        }

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

        public FishSpec GenerateRandomFish(FishType type)
        {
            // TODO: Generate random location for the fish according to game logic.
            Vector2 location = new Vector2(0, 0);
            return new FishSpec(type, location);
        }
    }
}
