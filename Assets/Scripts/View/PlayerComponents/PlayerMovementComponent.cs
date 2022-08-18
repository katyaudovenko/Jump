using UnityEngine;

namespace View.PlayerComponents
{
    public class PlayerMovementComponent : MonoBehaviour
    {
        private PlayerJump _jumpComponent;

        private void Awake() => 
            _jumpComponent = GetComponent<PlayerJump>();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) 
                _jumpComponent.Jump();
        }
    }
}