using System;
using System.Collections.Generic;
using Common;

namespace Contexts.EventService.Model
{
    public class EventServiceModel
    {
        private EventServiceModelData _data = new EventServiceModelData();

        public void InitializeData(EventServiceModelData data)
        {
            _data = data;
        }

        public void AddGameEventToData(GameEvent gameEvent)
        {
            _data.GameEvents.Add(gameEvent); 
        }

        public EventServiceModelData GetDataCopy()
        {
            var copy = new EventServiceModelData {GameEvents = new List<GameEvent>()};
            foreach (var gameEvent in _data.GameEvents)
            {
                copy.GameEvents.Add(gameEvent);
            }

            return copy;
        }

        public void RemoveGameEventFromData(GameEvent gameEvent)
        {
            _data.GameEvents.Remove(gameEvent);
        }
    }

    [Serializable]
    public class EventServiceModelData
    {
        public List<GameEvent> GameEvents = new List<GameEvent>();
    }
}