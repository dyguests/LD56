using UnityEngine;
using Wars.Views;

namespace Wars.ScriptableObjects
{
    [CreateAssetMenu(fileName = "FarmerSo", menuName = "Koyou/FarmerSo", order = 0)]
    public class FarmerSo : CreatureSo
    {
        public FarmerView prefab;
    }
}