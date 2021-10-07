using System;
using System.Collections;
using System.Collections.Generic;
using Contexts.Main;
using strange.extensions.context.impl;
using UnityEngine;

namespace Contexts.Main
{
    public class MainRoot : ContextView
    {
        private void Awake()
        {
            context = new MainContext(this);
        }
    }
}