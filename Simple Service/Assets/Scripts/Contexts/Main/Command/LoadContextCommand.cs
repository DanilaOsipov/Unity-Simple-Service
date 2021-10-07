using UnityEngine;
using UnityEngine.SceneManagement;

namespace Contexts.Main.Command
{
    public abstract class LoadContextCommand : strange.extensions.command.impl.Command
    {
        public override void Execute()
        {
            Retain();
            var asyncOperation = SceneManager.LoadSceneAsync(GetContextSceneName(), LoadSceneMode.Additive);
            asyncOperation.completed += AsyncOperationOnCompletedHandler;
        }

        private void AsyncOperationOnCompletedHandler(AsyncOperation operation)
        {
            Debug.Log("Scene loaded: " + GetContextSceneName());
            Release();
        }

        protected abstract string GetContextSceneName();
    }
}