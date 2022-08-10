using Model.PlayerComponents;
using UnityEngine;

namespace Model
{
    public class SlidingZone : MonoBehaviour
    {
        private const string PlayerTag = "Player";

        private PlayerJump _jumpComponent;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals(PlayerTag))
            {
                _jumpComponent = collision.gameObject.GetComponent<PlayerJump>();
                _jumpComponent.StopJump();
            }
        }
    }
}