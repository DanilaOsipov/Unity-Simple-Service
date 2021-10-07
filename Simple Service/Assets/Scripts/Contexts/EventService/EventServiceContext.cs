using Contexts.EventService.Command;
using Contexts.EventService.Model;
using Contexts.EventService.View;
using Contexts.Main;
using Contexts.Main.Command;
using Contexts.Main.View;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

namespace Contexts.EventService
{
    public class EventServiceContext : MVCSContext
    {
        public EventServiceContext(MonoBehaviour view) : base(view)
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
                .To<CheckEventServiceLocalDataExistenceCommand>()
                .To<LoadEventServiceLocalDataCommand>()
                .To<SendEventServiceDataCommand>()
                .To<DeleteEventServiceLocalDataCommand>()
                .InSequence()
                .Once();

            injectionBinder.Bind<SendEventServiceDataSignal>().ToSingleton();
            commandBinder.Bind<SendEventServiceDataSignal>().To<SendEventServiceDataCommand>();
            
            injectionBinder.Bind<GameEventTriggeredSignal>().ToSingleton().CrossContext();
            commandBinder.Bind<GameEventTriggeredSignal>().To<TrackEventCommand>();
            
            commandBinder.Bind<GameQuitSignal>().To<SaveEventServiceLocalDataCommand>();

            injectionBinder.Bind<EventServiceModel>().ToSingleton();

            mediationBinder.BindView<EventServiceTimerView>().ToMediator<EventServiceTimerMediator>();
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