using System;
using Libs.Components;
using UnityEngine;

namespace Model.ObstacleComponents
{
    public class CheckPoint : MonoBehaviour
    {
        public event Action OnCheckPoint;

        private CollisionComponent _collisionComponent;

        private void Awake() => 
            _collisionComponent = GetComponent<CollisionComponent>();

        private void OnEnable() => 
            _collisionComponent.OnCollisionEnter += CollisionEnter;

        private void OnDisable() => 
            _collisionComponent.OnCollisionEnter -= CollisionEnter;

        private void CollisionEnter(Collision2D collision2D) => 
            OnCheckPoint?.Invoke();
    }
}