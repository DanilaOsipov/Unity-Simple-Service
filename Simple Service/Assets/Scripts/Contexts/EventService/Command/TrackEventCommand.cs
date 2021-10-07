using Common;
using Contexts.EventService.Model;

namespace Contexts.EventService.Command
{
    public class TrackEventCommand : strange.extensions.command.impl.Command
    {
        [Inject] public GameEvent GameEvent { get; set; }
        
        public override void Execute()
        {
            injectionBinder.GetInstance<EventServiceModel>().AddGameEventToData(GameEvent);
        }
    }
}