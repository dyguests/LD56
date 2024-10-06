using Wars.Entities;

namespace Wars.Views
{
    public abstract class CreatureView<TData> : UnitView<TData>
        where TData : Creature { }
}