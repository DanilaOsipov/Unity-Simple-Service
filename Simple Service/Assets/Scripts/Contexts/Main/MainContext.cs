using Contexts.Main.Command;
using Contexts.Main.View;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

namespace Contexts.Main
{
    public class MainContext : MVCSContext
    {
        public MainContext(MonoBehaviour view) : base(view)
        {
        }

        public override IContext Start()
        {
            base.Start();
            var startSignal = injectionBinder.GetInstance<StartSignal>();
            startSignal.Dispatch();
            return this;
        }

        protected override void mapBindings()
        {
            injectionBinder.Bind<StartSignal>().ToSingleton();
            commandBinder.Bind<StartSignal>()
                .To<LoadEventServiceContextCommand>()
                .To<LoadTestContextCommand>()
                .InSequence()
                .Once();
            
            injectionBinder.Bind<GameEventTriggeredSignal>().ToSingleton().CrossContext();

            mediationBinder.BindView<MainView>().ToMediator<MainMediator>();
        }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        public override void OnRemove()
        {
            base.OnRemove();
            injectionBinder.CrossContextBinder.Unbind<GameEventTriggeredSignal>();
        }
    }
}