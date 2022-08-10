using System;
using Model.PlayerComponents;
using UnityEngine;

namespace Controller
{
    public class PlayerMovementController : MonoBehaviour
    {
        private const string SlidingZoneTag = "SlidingZone";
        private const string RunZone = "RunZone";

        private PlayerJump _jumpComponent;
        private PlayerRun _runComponent; 

        private void Awake()
        {
            _jumpComponent = GetComponent<PlayerJump>();
            _runComponent = GetComponent<PlayerRun>();
        }

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

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals(RunZone))
            {
                _jumpComponent.StopJump();
                _runComponent.Run();
            }
        }
    }
}