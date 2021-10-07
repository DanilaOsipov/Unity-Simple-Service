using Common;
using Contexts.EventService.Model;
using UnityEngine;
using UnityEngine.Networking;

namespace Contexts.EventService.Command
{
    public class SendEventServiceDataCommand : strange.extensions.command.impl.Command
    {
        private UnityWebRequest _request;
        EventServiceModel _eventServiceModel;
        public override void Execute()
        {
            Retain();
            Debug.Log("Sending data...");
            _eventServiceModel = injectionBinder.GetInstance<EventServiceModel>();
            var jsonString = _eventServiceModel.ConvertDataToJson();
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
                _eventServiceModel.ClearData();
            }
            _request.Dispose();
            Release();
        }
    }
}