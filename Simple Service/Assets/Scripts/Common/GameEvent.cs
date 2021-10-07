using System;

namespace Common
{
    [Serializable]
    public class GameEvent
    {
        public string Type;
        public string Data;
        
        public GameEvent(string type, string data)
        {
            Type = type;
            Data = data;
        }
    }
}