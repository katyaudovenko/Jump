using UnityEngine;

namespace Model.PlayerComponents
{
    public class PlayerJump : MonoBehaviour
    {
        private const float GravityScale = 0.01f;
        
        [SerializeField] private float jumpForce;

        private Rigidbody2D _rigidbody2D;
        private bool _inJump;
        private bool _isDoubleJump;
        
        private void Awake() => 
            _rigidbody2D = GetComponent<Rigidbody2D>();

        public void Jump()
        {
            if (!_inJump)
            {
                JumpInDirection();
                _inJump = true;
                return;
            }

            if (!_isDoubleJump)
            {
                transform.Rotate(0, 180, 0);
                JumpInDirection();
                _isDoubleJump = true;
            }
        }

        public void StopJump()
        {
            _inJump = false;
            _isDoubleJump = false;
            
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.gravityScale = GravityScale;
            transform.Rotate(0, 180, 0);
        }

        private void JumpInDirection() => 
            _rigidbody2D.velocity = (transform.right + Vector3.up).normalized * jumpForce;
    }
}