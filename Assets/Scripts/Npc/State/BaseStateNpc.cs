public abstract class BaseStateNpc 
{
    public Npc Npc;
    public StateMachineNpc StateMachineNpc;

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Perform();
}
