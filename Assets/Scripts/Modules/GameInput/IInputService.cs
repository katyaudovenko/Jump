using Infrastructure.Services;

namespace Modules.GameInput
{
    public interface IInputService : IService
    {
        bool IsJumpPressed();
    }
}