namespace Infrastructure.StateMachine.States
{
    public abstract class State
    {
        protected readonly StateMachine StateMachine;

        protected State(StateMachine stateMachine) => 
            StateMachine = stateMachine;
        
        public virtual void Enter() {}
        public virtual void Exit() {}
    }
}