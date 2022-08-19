using Infrastructure.Services;
using Modules.GameInput;
using Modules.Score;
using Modules.Spawn.ObstacleSpawn;
using UnityEngine;

namespace Infrastructure.StateMachine.States
{
    public class RegisterState : State
    {
        public RegisterState(StateMachine stateMachine) : base(stateMachine) => 
            RegisterServices();

        public override void Enter()
        {
            base.Enter();
            InitializeServices();
            StateMachine.ChangeState<LoadDataState>();
        }

        private void RegisterServices()
        {
            ServiceLocator.Instance.Register(new ObstaclesFactory());
            ServiceLocator.Instance.Register(new ScoreService());
            ServiceLocator.Instance.Register<IInputService>(new StandaloneInputService());
        }

        private void InitializeServices()
        {
            ServiceLocator.Instance.GetService<ObstaclesFactory>().Initialize();
        }
    }
}