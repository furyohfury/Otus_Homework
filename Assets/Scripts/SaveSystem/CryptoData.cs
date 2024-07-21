using System.Security.Cryptography;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.SaveLoad
{
    [CreateAssetMenu(fileName = "CryptoData", menuName = "Create config/CryptoData")]
    public sealed class CryptoData : ScriptableObject
    {
        public byte[] Key;
        public byte[] IV;

        [Button]
        public void GenerateKeyAndIV ()
        {
            using (Aes myAes = Aes.Create())
            {
                Key = myAes.Key;
                IV = myAes.IV;
            }
        }
    }
}