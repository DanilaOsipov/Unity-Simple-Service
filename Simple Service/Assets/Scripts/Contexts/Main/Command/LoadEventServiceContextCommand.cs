using Common;

namespace Contexts.Main.Command
{
    public class LoadEventServiceContextCommand : LoadContextCommand
    {
        protected override string GetContextSceneName() => ContextSceneNames.EVENT_SERVICE_SCENE;
    }
}