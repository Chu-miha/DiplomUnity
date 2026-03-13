using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttakState : BaseStateEnemy
{
    public override void Enter()
    {
        enemy.ChangedSpeed(0);
        enemy.currentState = "Атакую";
        enemy.Agent.isStopped = true;
        
    }

    public override void Exit()
    {
        //enemy.whoHeatMy = false;
        enemy.Agent.isStopped = false;
        enemy.ChangedSpeed(4);
    }

    public override void Perform()
    {
        float distanceToPlayer = Vector3.Distance(enemy.Target.transform.position, enemy.Agent.transform.position);
       
        if (distanceToPlayer > enemy.distanceForAttakPlayer)
        {
            stateMachineEnemy.ChangeState(stateMachineEnemy.chaseState);
        }
        enemy.AttakPlayer();

    }
}
