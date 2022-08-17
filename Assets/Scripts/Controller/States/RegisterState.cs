using Controller.Spawn.ObstacleSpawn;
using Model.Services.ServiceLocator;

namespace Controller.States
{
    public class RegisterState : State
    {
        public RegisterState(StateMachine stateMachine) : base(stateMachine)
        {
            RegisterServices();
        }

        public override void Enter()
        {
            base.Enter();
            InitializeServices();
            StateMachine.ChangeState<LoadDataState>();
        }

        private void RegisterServices()
        {
            ServiceLocator.Instance.Register(new GameFactory());
        }

        private void InitializeServices()
        {
            ServiceLocator.Instance.GetService<GameFactory>().Initialize();
        }
    }
}