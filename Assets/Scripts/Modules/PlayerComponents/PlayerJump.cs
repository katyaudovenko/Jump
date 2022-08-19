using Infrastructure.Services;
using Libs.Components;
using Modules.GameInput;
using UnityEngine;

namespace Modules.PlayerComponents
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private float increasingValue;
        [SerializeField] private float jumpForce;
        [SerializeField] private float jumpingGravity;

        private RigidbodyComponent _rigidbody;
        private IInputService _inputService;
        
        private bool _inJump;
        private bool _isDoubleJump;
        
        private void Awake()
        {
            _rigidbody = GetComponent<RigidbodyComponent>();
            _inputService = ServiceLocator.Instance.GetService<IInputService>();
        }

        private void OnEnable() => 
            _inputService.OnHighJumpHandler += HighJump;

        private void OnDisable() => 
            _inputService.OnHighJumpHandler -= HighJump;

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
                Flip();
                JumpInDirection();
                _isDoubleJump = true;
            }
        }

        public void OnIntersect(float slidingGravity)
        {
            StopJump();
            _rigidbody.ChangeGravity(slidingGravity);
        }

        public void ResetJumpState()
        {
            _inJump = false;
            _isDoubleJump = false;
        }

        private void HighJump()
        {
            if(_inJump) 
                _rigidbody.IncreaseVelocity(Vector2.up * increasingValue);
        }

        private void StopJump()
        {
            Flip();
            ResetJumpState();

            _rigidbody.ResetVelocity();
        }

        private void Flip() => 
            transform.Rotate(0, 180, 0);

        private void JumpInDirection()
        {
            _rigidbody.ChangeVelocity((transform.right + Vector3.up).normalized * jumpForce);
            _rigidbody.ChangeGravity(jumpingGravity);
        }
    }
}