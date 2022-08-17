﻿namespace Controller.States
{
    public class LoadDataState : State
    {
        public LoadDataState(StateMachine stateMachine) : base(stateMachine)
        {
        }
        public override void Enter()
        {
            base.Enter();
            LoadData();
            StateMachine.ChangeState<GameLoopState>();
        }

        private void LoadData()
        {
            
        }
    }
}