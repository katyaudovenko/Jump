using Modules.Events;

namespace Infrastructure.StateMachine.States
{
    public class GameLoopState : State
    {
        public GameLoopState(StateMachine stateMachine) : base(stateMachine)
        {
        }
        public override void Enter()
        {
            base.Enter();
            GlobalEventManager.OnStartGame();
        }
    }
}