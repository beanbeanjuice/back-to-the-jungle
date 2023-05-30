using System.ComponentModel;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fish
{
    [CreateAssetMenu]
    public class FishBindings : ScriptableObject
    {

        [System.Serializable]
        private class FishTypeEntry
        {
            [FormerlySerializedAs("color")]
            [SerializeField] private FishType type;
            [SerializeField] private Sprite sprite;

            public FishType GetColor()
            {
                return this.type;
            }

            public Sprite GetSprite()
            {
                return this.sprite;
            }
        }

        [SerializeField] private FishTypeEntry[] fishTypes;

        public Sprite GetFishSprite(FishType type)
        {
            foreach (FishTypeEntry fishTypeEntry in this.fishTypes)
                if (fishTypeEntry.GetColor() == type) return fishTypeEntry.GetSprite();

            throw new InvalidEnumArgumentException("Invalid color passed. Color does not exist in list.");
        }
    }
}
