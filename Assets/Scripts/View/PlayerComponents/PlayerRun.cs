using Libs.Components;
using UnityEngine;

namespace View.PlayerComponents
{
    public class PlayerRun : MonoBehaviour
    {
        [SerializeField] private float speedRun;

        private RigidbodyComponent _rigidbody;

        
        
        private void Awake() => 
            _rigidbody = GetComponent<RigidbodyComponent>();

        public void Run() => 
            _rigidbody.ChangeVelocity(transform.right * speedRun);
    }
}