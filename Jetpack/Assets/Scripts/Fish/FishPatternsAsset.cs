using UnityEngine;

namespace Fish
{
    public sealed class FishPatternsAsset : ScriptableObject
    {
        [SerializeField] private FishPattern[] m_fishPatterns;

        public FishPattern[] fishPatterns => (FishPattern[])this.m_fishPatterns.Clone();

        public static FishPatternsAsset CreatePatterns(FishPattern[] patterns)
        {
            FishPatternsAsset asset = CreateInstance<FishPatternsAsset>();
            asset.m_fishPatterns = (FishPattern[])patterns.Clone();
            Debug.Log($"SIZEEEE: {asset.fishPatterns.Length}");
            return asset;
        }
    }
}
