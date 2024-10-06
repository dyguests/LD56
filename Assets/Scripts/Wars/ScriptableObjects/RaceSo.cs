using UnityEngine;
using Wars.Views;

namespace Wars.ScriptableObjects
{
    [CreateAssetMenu(fileName = "RaceSo", menuName = "Koyou/RaceSo", order = 0)]
    public class RaceSo : ScriptableObject
    {
        public MainbaseSo mainbaseSo;
    }
}