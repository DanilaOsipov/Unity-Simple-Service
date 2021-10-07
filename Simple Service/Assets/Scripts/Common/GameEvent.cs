namespace Common
{
    public class GameEvent
    {
        public const string GAME_QUIT = "GAME_QUIT";
        
        public string Type;
        public string Data;
        
        public GameEvent(string type, string data)
        {
            Type = type;
            Data = data;
        }
    }
}