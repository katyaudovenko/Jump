using Infrastructure.StateMachine.States;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private static Bootstrapper _instance;

        private static StateMachine.StateMachine _stateMachine;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(this);
                return;
            }

            _instance = this;
            StartStateMachine();
            DontDestroyOnLoad(this);
        }

        private void StartStateMachine()
        {
            _stateMachine = new StateMachine.StateMachine();
            _stateMachine.ChangeState<RegisterState>();
        }
    }
}