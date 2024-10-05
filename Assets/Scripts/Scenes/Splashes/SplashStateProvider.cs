using Koyou.Frameworks;

namespace Scenes.Splashes
{
    public class SplashStateProvider:AppStateProvider
    {
        public override IAppState GetState() => new SplashState();
    }
}