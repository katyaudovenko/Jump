using UnityEngine;

namespace Model.PlayerComponents
{
    public class PlayerRun : MonoBehaviour
    {
        [SerializeField] private float speedRun;

        private Rigidbody2D _rigidbody2D;
        private PlayerJump _playerJump;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerJump = GetComponent<PlayerJump>();
        }

        public void Run()
        {
            _playerJump.ResetJump();
            _rigidbody2D.velocity = transform.right * speedRun;
        }
    }
}