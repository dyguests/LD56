using UnityEngine;
using Wars.Entities;
using Wars.Views;

namespace Wars.ScriptableObjects
{
    [CreateAssetMenu(fileName = "MainbaseSo", menuName = "Koyou/MainbaseSo", order = 0)]
    public class MainbaseSo : BuildingSo
    {
        public MainbaseBase mainbaseBase;
        public MainbaseView prefab;
    }
}