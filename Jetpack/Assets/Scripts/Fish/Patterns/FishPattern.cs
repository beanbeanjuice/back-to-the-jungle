using System;
using UnityEngine;

namespace Fish.Pattern
{
    [CreateAssetMenu]
    public class FishPattern : ScriptableObject
    {
        [SerializeField] private Vector2[] offsets;

        public int GetFishCount()
        {
            return this.offsets.Length;
        }

        public Vector2[] GetLocationOffsets()
        {
            return this.offsets;
        }
    }
}
