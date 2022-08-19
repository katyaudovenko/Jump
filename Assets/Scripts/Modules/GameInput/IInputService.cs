using System;
using Infrastructure.Services;

namespace Modules.GameInput
{
    public interface IInputService : IService
    { 
        public event Action OnHighJumpHandler;
        bool IsJumpPressed();
    }
}