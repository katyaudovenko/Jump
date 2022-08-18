using System;
using UnityEngine;

namespace Libs.Components
{
    public class TriggerComponent : MonoBehaviour
    {
        public event Action<Collider2D> OnTriggerEnter;
        public event Action<Collider2D> OnTriggerStay;
        public event Action<Collider2D> OnTriggerExit;

        private void OnTriggerEnter2D(Collider2D trigger) => 
            OnTriggerEnter?.Invoke(trigger);

        private void OnTriggerStay2D(Collider2D trigger) => 
            OnTriggerStay?.Invoke(trigger);

        private void OnTriggerExit2D(Collider2D trigger) => 
            OnTriggerExit?.Invoke(trigger);
    }
}