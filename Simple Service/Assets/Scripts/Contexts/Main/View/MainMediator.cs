using Common;
using strange.extensions.mediation.impl;

namespace Contexts.Main.View
{
    public class MainMediator : Mediator
    {
        [Inject] public MainView View { get; set; }
        [Inject] public GameQuitSignal GameQuitSignal { get; set; }
        
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
            GameQuitSignal.Dispatch();
        }
    }
}