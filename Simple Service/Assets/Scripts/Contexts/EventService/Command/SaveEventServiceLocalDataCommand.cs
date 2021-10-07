using System.IO;
using Common;
using Contexts.EventService.Model;
using UnityEngine;

namespace Contexts.EventService.Command
{
    public class SaveEventServiceLocalDataCommand : strange.extensions.command.impl.Command
    {
        public override void Execute()
        {
            var localData = injectionBinder.GetInstance<EventServiceModel>().GetDataCopy();
            var text = JsonUtility.ToJson(localData);
            File.WriteAllText(ResourcePaths.EVENT_SERVICE_LOCAL_DATA_PATH, text);
            Debug.Log("Saved data: " + text);
        }
    }
}