using System;
using Model.PlayerComponents;
using UnityEngine;

namespace Model
{
    public class CheckPoint : MonoBehaviour
    {
        public event Action OnCheckPoint;

        private PlayerJump _jumpComponent;
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            OnCheckPoint?.Invoke();
            _jumpComponent = col.gameObject.GetComponent<PlayerJump>();
            _jumpComponent.StopJump();
        }
    }
}