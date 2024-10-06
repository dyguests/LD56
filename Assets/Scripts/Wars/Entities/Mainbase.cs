namespace Wars.Entities
{
    public class Mainbase : Building
    {
        public static Mainbase CreateFrom(MainbaseBase mainbaseBase)
        {
            return new Mainbase(mainbaseBase);
        }

        private Mainbase(MainbaseBase mainbaseBase) : base(mainbaseBase) { }
    }
}