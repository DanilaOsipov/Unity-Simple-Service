using System;

namespace Contexts.Main.View
{
    public class MainView : strange.extensions.mediation.impl.View
    {
        public event Action OnGameQuit = delegate { };
        
        private void OnApplicationQuit()
        {
            OnGameQuit();
        }
    }
}