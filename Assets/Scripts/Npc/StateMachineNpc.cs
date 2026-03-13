using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineNpc : MonoBehaviour
{
    public BaseStateNpc activeState;
    public Walk Walk;
    public InteractionWithThePlayer InteractionWithThePlayer;
 

    public void Initialise()
    {
        Walk = new Walk();
        InteractionWithThePlayer = new InteractionWithThePlayer();
        ChangeState(Walk);
    }
    void Start()
    {

    }

    void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }

    }

    public void ChangeState(BaseStateNpc newState)
    {
        if (activeState != null)
        {
            activeState.Exit();
        }

        activeState = newState;

        if (activeState != null)
        {
            activeState.StateMachineNpc = this;
            activeState.Npc = GetComponent<Npc>();
            activeState.Enter();
        }
    }
}
