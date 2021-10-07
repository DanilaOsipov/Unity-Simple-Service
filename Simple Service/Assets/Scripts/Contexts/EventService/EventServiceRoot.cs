using System;
using strange.extensions.context.impl;

namespace Contexts.EventService
{
    public class EventServiceRoot : ContextView
    {
        private void Awake()
        {
            context = new EventServiceContext(this);
        }
    }
}