using System;
using strange.extensions.context.impl;

namespace Contexts.Test
{
    public class TestRoot : ContextView
    {
        private void Awake()
        {
            context = new TestContext(this);
        }
    }
}