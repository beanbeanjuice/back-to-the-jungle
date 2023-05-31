using System;
using UnityEngine;

namespace Fish.Pattern
{
    [CreateAssetMenu]
    public class FishPatterns : ScriptableObject
    {
        [SerializeField] private FishPattern[] fishPatterns;

        public FishPattern[] GetPatterns()
        {
            return this.fishPatterns;
        }
    }
}
