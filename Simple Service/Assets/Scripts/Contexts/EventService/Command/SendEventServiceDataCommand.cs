using Common;
using Contexts.EventService.Model;
using UnityEngine;
using UnityEngine.Networking;

namespace Contexts.EventService.Command
{
    public class SendEventServiceDataCommand : strange.extensions.command.impl.Command
    {
        private UnityWebRequest _request;
        private EventServiceModel _eventServiceModel;
        private EventServiceModelData _copy;

        public override void Execute()
        {
            Retain();
            Debug.Log("Sending data...");
            _eventServiceModel = injectionBinder.GetInstance<EventServiceModel>();
            _copy = _eventServiceModel.GetDataCopy();
            if (_copy.GameEvents.Count == 0)
            {
                Debug.Log("Data is empty");
                Release();
                return;
            }
            var jsonString = JsonUtility.ToJson(_copy);
            var url = ResourcePaths.ANALYTICS_SERVER_URL;
            _request = UnityWebRequest.Put(url, jsonString);
            _request.method = UnityWebRequest.kHttpVerbPOST;
            _request.SetRequestHeader("Content-Type", "application/json");
            _request.SetRequestHeader("Accept", "application/json");
            var asyncOperation = _request.SendWebRequest();
            asyncOperation.completed += AsyncOperationOnCompletedHandler;
        }

        private void AsyncOperationOnCompletedHandler(AsyncOperation operation)
        {
            if (!_request.isNetworkError && _request.responseCode == (long)ResponseCodes.OK)
            {
                Debug.Log("Data sent successfully");
                foreach (var gameEvent in _copy.GameEvents)
                {
                    _eventServiceModel.RemoveGameEventFromData(gameEvent);   
                }
            }
            _request.Dispose();
            Release();
        }
    }
}