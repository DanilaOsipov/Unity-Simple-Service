using System.IO;
using Common;
using UnityEngine;

namespace Contexts.EventService.Command
{
    public class CheckEventServiceLocalDataExistenceCommand : strange.extensions.command.impl.Command
    {
        public override void Execute()
        {
            Debug.Log("Checking Event Service local data existence...");

            if (File.Exists(ResourcePaths.EVENT_SERVICE_LOCAL_DATA_PATH))
            {
                Debug.Log("Event Service local data exists");
            }
            else
            {
                Debug.Log("Event Service local data not exists");
                Fail();
            }
        }
    }
}