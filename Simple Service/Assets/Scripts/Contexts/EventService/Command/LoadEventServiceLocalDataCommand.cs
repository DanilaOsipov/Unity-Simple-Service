using System.IO;
using Common;
using Contexts.EventService.Model;
using UnityEngine;

namespace Contexts.EventService.Command
{
    public class LoadEventServiceLocalDataCommand : strange.extensions.command.impl.Command
    {
        public override void Execute()
        {
            var text = File.ReadAllText(ResourcePaths.EVENT_SERVICE_LOCAL_DATA_PATH);
            if (string.IsNullOrEmpty(text)) return;
            Debug.Log("Loaded data: " + text);
            var localData = JsonUtility.FromJson<EventServiceModelData>(text);
            if (localData.GameEvents.Count == 0)
            {
                Debug.Log("Data is empty");
                Fail();
            }
            else
            {
                injectionBinder.GetInstance<EventServiceModel>().InitializeData(localData);
            }
        }
    }
}