using Contexts.Test.View;
using strange.extensions.context.impl;
using UnityEngine;

namespace Contexts.Test
{
    public class TestContext : MVCSContext
    {
        public TestContext(MonoBehaviour view) : base(view)
        {
        }

        protected override void mapBindings()
        {
            mediationBinder.BindView<TestView>().ToMediator<TestMediator>();
        }
    }
}