using Common;
using UnityEngine;
using UnityEngine.Windows;

namespace Contexts.EventService.Command
{
    public class DeleteEventServiceLocalDataCommand : strange.extensions.command.impl.Command
    {
        public override void Execute()
        {
            File.Delete(ResourcePaths.EVENT_SERVICE_LOCAL_DATA_PATH);
            Debug.Log("Event Service local data deleted");
        }
    }
}