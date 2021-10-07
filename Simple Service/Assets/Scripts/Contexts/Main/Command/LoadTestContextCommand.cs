using Common;

namespace Contexts.Main.Command
{
    public class LoadTestContextCommand : LoadContextCommand
    {
        protected override string GetContextSceneName() => ContextSceneNames.TEST_SCENE;
    }
}