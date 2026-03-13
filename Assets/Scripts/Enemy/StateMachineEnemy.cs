using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineEnemy : MonoBehaviour
{
    public BaseStateEnemy activeState;
    public PatrolState patrolState;
    public ChaseState chaseState;
    public AttakState attakState;

    public void Initialise()
    {
        patrolState = new PatrolState();
        chaseState = new ChaseState();
        attakState = new AttakState();
        ChangeState(patrolState);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }

    }

    public void ChangeState(BaseStateEnemy newState)
    {
        if (activeState != null)
        {
            activeState.Exit();
        }

        activeState = newState;

        if (activeState != null)
        {
            activeState.stateMachineEnemy = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
