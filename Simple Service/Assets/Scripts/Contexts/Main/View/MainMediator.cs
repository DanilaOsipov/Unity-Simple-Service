using Common;
using strange.extensions.mediation.impl;

namespace Contexts.Main.View
{
    public class MainMediator : Mediator
    {
        [Inject] public MainView View { get; set; }
        [Inject] public GameEventTriggeredSignal GameEventTriggeredSignal { get; set; }
        
        public override void OnRegister()
        {
            View.OnGameQuit += OnGameQuitHandler;
        }

        public override void OnRemove()
        {
            View.OnGameQuit -= OnGameQuitHandler;
        }

        private void OnGameQuitHandler()
        {
            GameEventTriggeredSignal.Dispatch(new GameEvent(GameEvent.GAME_QUIT, null));
        }
    }
}