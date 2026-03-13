using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Npc : MonoBehaviour
{
    public NavMeshAgent Agent { get => agent; }
    public Path Path { get => path; }


    private StateMachineNpc stateMachineNpc;
    private NavMeshAgent agent;
    [SerializeField] private Path path;
    private Animator anim;

    void Start()
    {
        stateMachineNpc = GetComponent<StateMachineNpc>();
        agent = GetComponent<NavMeshAgent>();
        stateMachineNpc.Initialise();
        anim = GetComponent<Animator>();
    }

    public void WalkAnim(bool walk)
    {
        anim.SetBool("Walk", walk);
    }

  
}
