using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseStateEnemy
{
    public int waypointIndex;
    public float waitTimer;
    public override void Enter()
    {
        
        enemy.currentState = "√ул€ю";
        enemy.StartWalkAnim();
   
    }

    public override void Exit()
    {

    }

    public override void Perform()
    {

        PatrolCycle();
        float distanceToPlayer = Vector3.Distance(enemy.Target.transform.position, enemy.Agent.transform.position);
        if (distanceToPlayer <= enemy.DetectionDistance || enemy.IsInView() /*|| enemy.whoHeatMy*/)
        {
            stateMachineEnemy.ChangeState(stateMachineEnemy.chaseState);
        }


    }

    public void PatrolCycle()
    {
        if (enemy.Agent.remainingDistance < 0.5f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer > 1)
            {
                if (waypointIndex < enemy.Path.waypoints.Count - 1) waypointIndex++;
                else waypointIndex = 0;
                enemy.Agent.SetDestination(enemy.Path.waypoints[waypointIndex].position);
                waitTimer = 0;
            }
        }
    }

}
