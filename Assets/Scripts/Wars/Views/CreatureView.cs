using Wars.Entities;

namespace Wars.Views
{
    public interface ICreatureView { }

    public abstract class CreatureView<TData> : UnitView<TData>,
        ICreatureView
        where TData : Creature { }
}