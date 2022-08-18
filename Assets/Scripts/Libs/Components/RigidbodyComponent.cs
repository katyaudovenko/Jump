using UnityEngine;

namespace Libs.Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RigidbodyComponent : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        private void Awake() => 
            _rigidbody2D = GetComponent<Rigidbody2D>();

        public void ChangeVelocity(Vector3 velocity) => 
            _rigidbody2D.velocity = velocity;

        public void ChangeGravity(float gravity) => 
            _rigidbody2D.gravityScale = gravity;

        public void ResetVelocity() => 
            _rigidbody2D.velocity = Vector2.zero;

        public void DisableGravity() => 
            _rigidbody2D.gravityScale = 0;
    }
}