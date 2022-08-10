using Model.PlayerComponents;
using UnityEngine;

namespace Controller
{
    public class PlayerMovementController : MonoBehaviour
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