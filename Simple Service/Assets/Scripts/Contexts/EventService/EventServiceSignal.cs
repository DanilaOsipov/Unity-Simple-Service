using Common;
using strange.extensions.signal.impl;

namespace Contexts.EventService
{
    public class StartSignal : Signal { }
    public class GameEventTriggeredSignal : Signal<GameEvent> { }
    public class SendEventServiceDataSignal : Signal { } 
}