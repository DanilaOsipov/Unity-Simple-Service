using System;
using System.Collections.Generic;
using Common;
using UnityEngine;

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

        public void ClearData()
        {
            _data.GameEvents.Clear();
        }

        public string ConvertDataToJson()
        {
            return JsonUtility.ToJson(_data);
        }

        public object GetDataCopy()
        {
            var copy = new EventServiceModelData {GameEvents = new List<GameEvent>()};
            foreach (var gameEvent in _data.GameEvents)
            {
                copy.GameEvents.Add(new GameEvent(gameEvent.Type, gameEvent.Data));
            }

            return copy;
        }
    }

    [Serializable]
    public class EventServiceModelData
    {
        public List<GameEvent> GameEvents = new List<GameEvent>();
    }
}