public class EnemyStateMachine
{
    public EnemyState CurrentState { get; private set; }

    public void Init(EnemyState initialState)
    {
        CurrentState = initialState;
        CurrentState.Enter();
    }

    public void ChangeState(EnemyState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
