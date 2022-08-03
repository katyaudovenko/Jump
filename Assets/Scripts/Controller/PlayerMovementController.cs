using Model.PlayerComponents;
using UnityEngine;

namespace Controller
{
    public class PlayerMovementController : MonoBehaviour
    {
        private const string SlidingZoneTag = "SlidingZone";
        
        private PlayerJump _jumpComponent;

        private void Awake() => 
            _jumpComponent = GetComponent<PlayerJump>();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) 
                _jumpComponent.Jump();
        }
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag.Equals(SlidingZoneTag)) 
                _jumpComponent.StopJump();
        }

    }
}