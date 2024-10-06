using System;

namespace Wars.Entities
{
    [Serializable]
    public abstract class Creature : Unit
    {
        protected Creature(CreatureBase creatureBase):base(creatureBase) { }
    }
}