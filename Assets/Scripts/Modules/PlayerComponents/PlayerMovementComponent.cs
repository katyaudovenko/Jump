using Infrastructure.Services;
using Modules.GameInput;
using UnityEngine;

namespace Modules.PlayerComponents
{
    public class PlayerMovementComponent : MonoBehaviour
    {
        private PlayerJump _jumpComponent;
        private IInputService _inputService;

        private void Awake()
        {
            _jumpComponent = GetComponent<PlayerJump>();
            _inputService = ServiceLocator.Instance.GetService<IInputService>();
        }

        private void Update()
        {
            if (_inputService.IsJumpPressed()) 
                _jumpComponent.Jump();
        }
    }
}