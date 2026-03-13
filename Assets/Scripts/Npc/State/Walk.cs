using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : BaseStateNpc
{
    public int waypointIndex;
    public float waitTimer;
    public override void Enter()
    {
        //enemy.currentState = "√ул€ю";
        Npc.WalkAnim(true);

    }

    public override void Exit()
    {

    }

    public override void Perform()
    {

        PatrolCycle();

    }

    public void PatrolCycle()
    {
        if (Npc.Agent.remainingDistance < 0.5f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer > 1)
            {
                if (waypointIndex < Npc.Path.waypoints.Count - 1) waypointIndex++;
                else waypointIndex = 0;
                Npc.Agent.SetDestination(Npc.Path.waypoints[waypointIndex].position);
                waitTimer = 0;
            }
        }
    }
}
