using UnityEngine;
using Wars.Entities;

namespace Wars.Views
{
    public class FarmerView : CreatureView<Farmer>
    {
        [SerializeField] private Farmer farmer;
    }
}