using UnityEngine;

namespace Modules.GameInput
{
    public class StandaloneInputService : IInputService
    {
        public bool IsJumpPressed() => Input.GetMouseButtonDown(0);
    }
}