using Libs.Components;
using Modules.PlayerComponents;
using UnityEngine;

namespace Modules.ObstacleComponents
{
    public class RunZone : MonoBehaviour
    {
        private CollisionComponent _collisionComponent;
        
        private Collision2D _playerCollision;
        private PlayerRun _runComponent;
        private PlayerJump _jumpComponent;

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
                _runComponent = collision.gameObject.GetComponent<PlayerRun>();
                _jumpComponent = collision.gameObject.GetComponent<PlayerJump>();
                _playerCollision = collision;
            }
            
            _jumpComponent.ResetJumpState();
            _runComponent.Run();
        }
    }
}