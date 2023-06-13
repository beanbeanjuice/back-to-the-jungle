using UnityEngine;

namespace Resources.Patterns.Fish
{
    /// <summary>
    /// A sealed class used for reading bytes from the "Resources" folder.
    /// <remarks>Coded by William.</remarks>
    /// <a href="https://forum.unity.com/threads/how-create-a-textasset-from-external-binary-file.1112608/">Partial source.</a>
    /// </summary>
    public sealed class CustomTextAsset : ScriptableObject
    {
        [SerializeField] private byte[] m_bytes;
        public byte[] bytes => (byte[])this.m_bytes.Clone();

        public static CustomTextAsset CreateAsset(byte[] newBytes)
        {
            CustomTextAsset asset = CreateInstance<CustomTextAsset>();
            asset.m_bytes = (byte[])newBytes.Clone();
            return asset;
        }
    }
}
