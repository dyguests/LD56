using UnityEngine;
using Wars.Entities;
using Wars.Views;

namespace Wars.ScriptableObjects
{
    [CreateAssetMenu(fileName = "FarmerSo", menuName = "Koyou/FarmerSo", order = 0)]
    public class FarmerSo : CreatureSo
    {
        public FarmerBase farmerBase;
        public FarmerView prefab;
    }
}