using System;
using UnityEngine;

namespace Libs.Components
{
    public class CollisionComponent : MonoBehaviour
    {
        public event Action<Collision2D> OnCollisionEnter;
        public event Action<Collision2D> OnCollisionStay;
        public event Action<Collision2D> OnCollisionExit;

        private void OnCollisionEnter2D(Collision2D collision) => 
            OnCollisionEnter?.Invoke(collision);

        private void OnCollisionStay2D(Collision2D collision) => 
            OnCollisionStay?.Invoke(collision);

        private void OnCollisionExit2D(Collision2D collision) => 
            OnCollisionExit?.Invoke(collision);
    }
}