using UnityEngine;

namespace Fish
{
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
