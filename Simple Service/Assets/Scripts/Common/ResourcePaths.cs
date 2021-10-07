using UnityEngine;

namespace Common
{
    public class ResourcePaths
    {
        public static readonly string EVENT_SERVICE_LOCAL_DATA_PATH
            = Application.persistentDataPath + "/eventSerivce.json";
        
        public const string ANALYTICS_SERVER_URL = "https://webhook.site/06fe0c53-57bb-4ea8-8916-a33e2f8555c3";
    }
}