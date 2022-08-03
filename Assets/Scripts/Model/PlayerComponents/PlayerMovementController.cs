using UnityEngine;

namespace Model.PlayerComponents
{
    public class PlayerMovementController : MonoBehaviour
    {
        private const string SlidingZoneTag = "SlidingZone";
        
        private PlayerJump _jumpComponent;

        private void Awake() => 
            _jumpComponent = GetComponent<PlayerJump>();

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) 
                return;
            
            _jumpComponent.Jump();
            
            if (!_jumpComponent.IsProp) 
                _jumpComponent.DoubleJump();

        }
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag.Equals(SlidingZoneTag)) 
                _jumpComponent.StopJump();
        }

    }
}