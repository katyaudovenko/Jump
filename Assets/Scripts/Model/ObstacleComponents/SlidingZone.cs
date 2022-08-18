using Libs.Components;
using Model.PlayerComponents;
using UnityEngine;

namespace Model.ObstacleComponents
{
    public class SlidingZone : MonoBehaviour
    {
        [SerializeField] private float slidingGravity = 0.05f;

        private CollisionComponent _collisionComponent;
        private PlayerJump _jumpComponent;
        private Collision2D _playerCollision;

        private void Awake() => 
            _collisionComponent = GetComponent<CollisionComponent>();

        private void OnEnable() => 
            _collisionComponent.OnCollisionEnter += CollisionEnter;

        private void OnDisable() => 
            _collisionComponent.OnCollisionEnter -= CollisionEnter;
        
        private void CollisionEnter(Collision2D collision)
        {
            if(_playerCollision != collision)
            {
                _jumpComponent = collision.gameObject.GetComponent<PlayerJump>();
                _playerCollision = collision;
            }
            
            _jumpComponent.OnIntersect(slidingGravity);
        }
    }
}