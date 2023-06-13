using UnityEngine;

namespace Fish
{
    /// <summary>
    /// A sealed class used for creating the "FishPatterns" asset.
    /// <remarks>Coded by William.</remarks>
    /// <a href="https://forum.unity.com/threads/how-create-a-textasset-from-external-binary-file.1112608/">Partial source.</a>
    /// </summary>
    public sealed class FishPatternsAsset : ScriptableObject
    {
        [SerializeField] private FishPattern[] m_fishPatterns;

        public FishPattern[] fishPatterns => (FishPattern[])this.m_fishPatterns.Clone();

        /// <summary>
        /// Creates a new instance of the Fish Patterns asset.
        /// </summary>
        /// <param name="patterns">The actual fish patterns.</param>
        /// <returns>A new instance of the Fish Patterns asset.</returns>
        public static FishPatternsAsset CreatePatterns(FishPattern[] patterns)
        {
            FishPatternsAsset asset = CreateInstance<FishPatternsAsset>();
            asset.m_fishPatterns = (FishPattern[])patterns.Clone();
            Debug.Log($"SIZEEEE: {asset.fishPatterns.Length}");
            return asset;
        }
    }
}
