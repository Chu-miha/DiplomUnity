public abstract class BaseStateEnemy
{
    public Enemy enemy;
    public StateMachineEnemy stateMachineEnemy;

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Perform();
}
