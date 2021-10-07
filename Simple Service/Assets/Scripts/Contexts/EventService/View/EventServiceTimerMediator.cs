using Contexts.EventService.Model;
using strange.extensions.mediation.impl;

namespace Contexts.EventService.View
{
    public class EventServiceTimerMediator : Mediator
    {
        [Inject] public EventServiceTimerView View { get; set; }
        [Inject] public SendEventServiceDataSignal SendEventServiceDataSignal { get; set; }
        
        public override void OnRegister()
        {
            View.OnCooldownEnded += OnCooldownEndedHandler;
        }

        public override void OnRemove()
        {
            View.OnCooldownEnded -= OnCooldownEndedHandler;
        }

        private void OnCooldownEndedHandler()
        {
            SendEventServiceDataSignal.Dispatch();
        }
    }
}