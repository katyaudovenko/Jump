using UnityEngine;

namespace Model.PlayerComponents
{
    public class PlayerJump : MonoBehaviour
    {
        private const float GravityScale = 0.01f;
        
        [SerializeField] private float jumpForce;

        public bool IsProp { get; private set; }
        private Rigidbody2D _rigidbody2D;

        private void Awake() => 
            _rigidbody2D = GetComponent<Rigidbody2D>();
        
        public void Jump()
        {
            IsProp = false;
            _rigidbody2D.velocity = (transform.right + Vector3.up).normalized * jumpForce;
        }

        public void DoubleJump()
        {
            Jump();
            transform.Rotate(0,180,0);
        }

        public void StopJump()
        {
            IsProp = true;
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.gravityScale = GravityScale;
        }
    }
}