using UnityEngine;
using Wars.Entities;

namespace Wars.Views
{
    public class FarmerView : CreatureView<Farmer>
    {
        [SerializeField] private Farmer farmer;

        public FarmerView Duplicate(Vector3 position)
        {
            var instance = Instantiate(this, position, Quaternion.identity);
            instance.name = $"Farmer{GenerateId()}";
            return instance;
        }
    }
}