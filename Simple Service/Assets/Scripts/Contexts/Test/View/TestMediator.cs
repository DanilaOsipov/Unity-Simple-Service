using Common;
using Contexts.EventService;
using strange.extensions.mediation.impl;

namespace Contexts.Test.View
{
    public class TestMediator : Mediator
    {
        [Inject] public TestView View { get; set; }
        [Inject] public GameEventTriggeredSignal GameEventTriggeredSignal { get; set; }
        
        public override void OnRegister()
        {
            View.OnEventTriggered += OnEventTriggeredHandler;
        }

        public override void OnRemove()
        {
            View.OnEventTriggered -= OnEventTriggeredHandler;
        }

        private void OnEventTriggeredHandler(GameEvent gameEvent)
        {
            GameEventTriggeredSignal.Dispatch(gameEvent);
        }
    }
}