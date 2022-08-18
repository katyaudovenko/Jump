using Libs.Components;
using Model.PlayerComponents;
using UnityEngine;

namespace Model.ObstacleComponents
{
    public class RunZone : MonoBehaviour
    {
        private CollisionComponent _collisionComponent;

        private void Awake() =>
            _collisionComponent = GetComponent<CollisionComponent>();

        private void OnEnable() => 
            _collisionComponent.OnCollisionEnter += CollisionEnter;

        private void OnDisable() => 
            _collisionComponent.OnCollisionEnter -= CollisionEnter;

        private void CollisionEnter(Collision2D collision)
        {
            var runComponent = collision.gameObject.GetComponent<PlayerRun>();
            var jumpComponent = collision.gameObject.GetComponent<PlayerJump>();
            
            jumpComponent.ResetJumpState();
            runComponent.Run();
        }
    }
}