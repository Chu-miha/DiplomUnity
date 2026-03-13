using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseStateEnemy
{
    public override void Enter()
    {
        enemy.currentState = "Преследую";
    }

    public override void Exit()
    {
        //enemy.whoHeatMy = false;
    }

    public override void Perform()
    {
        enemy.MoveToTarget();
        float distanceToPlayer = Vector3.Distance(enemy.Target.transform.position, enemy.Agent.transform.position);
        if (distanceToPlayer > enemy.DetectionDistance && !enemy.IsInView() /*&& !enemy.whoHeatMy*/)
        {
            stateMachineEnemy.ChangeState(stateMachineEnemy.patrolState);
        }
        if (distanceToPlayer < enemy.distanceForAttakPlayer)
        {
            stateMachineEnemy.ChangeState(stateMachineEnemy.attakState);
        }

    }

    
}
