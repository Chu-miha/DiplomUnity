using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTalk : MonoBehaviour, INPCInteraction
{
    [SerializeField] float distanceFromInteract;
    [SerializeField] Animator anim;
    [SerializeField] private string[] linesForDialog;

    public float DistanceToInteract
    {
        get
        {
            return distanceFromInteract;
        }
    }
    public void TriggerOnPlayerInteractionWithNpc()
    {
        MainManager.DialogManager.StartDialog(linesForDialog);
    }

    public void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Walk", false);
    }
}
