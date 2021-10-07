using System;
using System.Collections;
using UnityEngine;

namespace Contexts.EventService.View
{
    public class EventServiceTimerView : strange.extensions.mediation.impl.View
    {
        [SerializeField] private float _cooldownBeforeSend = 5.0f;

        public event Action OnCooldownEnded = delegate { Debug.Log("OnCooldownEnded"); };
        
        protected override void Start()
        {
            base.Start();

            StartCoroutine(TimerCoroutine());
        }

        private IEnumerator TimerCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_cooldownBeforeSend);
                OnCooldownEnded();
            }
        }
    }
}