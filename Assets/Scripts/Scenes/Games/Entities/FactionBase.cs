namespace Scenes.Games.Entities
{
    /// <summary>
    /// 势力基础设置，用于初始化势力
    /// </summary>
    public class FactionBase
    {
        public CtlrType ctlrType;
        public RaceType raceType;

        public enum CtlrType
        {
            Player,
            Ai,
            // Replayer,
            // Remote,
        }

        public enum RaceType
        {
            Frog,
            Spider,
            // todo
        }
    }
}