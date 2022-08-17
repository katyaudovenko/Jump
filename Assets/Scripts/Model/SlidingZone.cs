using Model.PlayerComponents;
using UnityEngine;

namespace Model
{
    public class SlidingZone : MonoBehaviour
    {
        private PlayerJump _jumpComponent;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            _jumpComponent = collision.gameObject.GetComponent<PlayerJump>();
            _jumpComponent.StopJumpOnSlidingZone();
        }
    }
}