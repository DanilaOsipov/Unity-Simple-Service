using System;
using System.Collections.Generic;
using Common;
using UnityEngine;
using Random = System.Random;

namespace Contexts.Test.View
{
    public class TestView : strange.extensions.mediation.impl.View
    {
        private List<string> _gameEvents = new List<string>()
        {
            GameEvents.LEVEL_STARTED,
            GameEvents.LEVEL_ENDED
        };

        public event Action<GameEvent> OnEventTriggered 
            = delegate(GameEvent gameEvent) { Debug.Log("OnEventTriggered " + gameEvent.Type); }; 
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var idx = UnityEngine.Random.Range(0, _gameEvents.Count);
                var gameEvent = new GameEvent(_gameEvents[idx], DateTime.Now.ToString());
                OnEventTriggered(gameEvent);
            }
        }
    }
}