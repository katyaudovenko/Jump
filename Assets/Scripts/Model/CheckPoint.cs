using System;
using UnityEngine;

namespace Model
{
    public class CheckPoint : MonoBehaviour
    {
        public event Action OnCheckPoint;

        private void OnCollisionEnter2D(Collision2D col)
        {
            OnCheckPoint?.Invoke();
        }
    }
}