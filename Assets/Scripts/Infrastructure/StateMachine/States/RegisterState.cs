using Infrastructure.Services;
using Modules.Game;
using Modules.GameInput;
using Modules.Score;
using Modules.Spawn.ObstacleSpawn;
using UnityEngine;

namespace Infrastructure.StateMachine.States
{
    public class RegisterState : State
    {
        private const string StandaloneInputServiceName = "StandaloneInputService";

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
            ServiceLocator.Instance.Register(new GameFactory());
            ServiceLocator.Instance.Register(new ObstaclesFactory());
            ServiceLocator.Instance.Register(new ScoreService());
            ServiceLocator.Instance.Register(CreateInputService());
        }

        private IInputService CreateInputService()
        {
            var gameObject = new GameObject(StandaloneInputServiceName);
            var service = gameObject.AddComponent<StandaloneInputService>();
            return service;
        }

        private void InitializeServices()
        {
            ServiceLocator.Instance.GetService<GameFactory>().Initialize();
            ServiceLocator.Instance.GetService<ObstaclesFactory>().Initialize();
        }
    }
}