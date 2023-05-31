using UnityEngine;

namespace Fish.Patterns
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
