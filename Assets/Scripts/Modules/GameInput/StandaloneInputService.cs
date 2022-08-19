using System;
using UnityEngine;

namespace Modules.GameInput
{
    public class StandaloneInputService : MonoBehaviour, IInputService
    {
        private const float MaxTime = 0.25f;
        private const float MinTime = 0.1f;
        public event Action OnHighJumpHandler;
        
        private bool _isJump;
        private float _time;

        public bool IsJumpPressed() => Input.GetMouseButtonDown(0);
        
        private void Update()
        {
            if (PlayerInJump()) return;

            if (PlayerInHighJump()) return;
        
            PlayerStopJump();
        }

        private bool PlayerInJump()
        {
            if (IsJumpPressed())
            {
                _isJump = true;
                return true;
            }

            return false;
        }

        private bool PlayerInHighJump()
        {
            if (_isJump && Input.GetMouseButton(0))
            {
                _time += Time.deltaTime;
                
                if(_time is >= MinTime and <= MaxTime)
                    OnHighJumpHandler?.Invoke();
                
                if (_time > MaxTime) 
                    ResetHighJump();

                return true;
            }

            return false;
        }

        private void PlayerStopJump()
        {
            if (Input.GetMouseButtonUp(0)) 
                ResetHighJump();
        }

        private void ResetHighJump()
        {
            _isJump = false;
            _time = 0;
        }
    }
}