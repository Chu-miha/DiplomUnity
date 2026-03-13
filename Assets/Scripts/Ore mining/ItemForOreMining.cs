using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemForOreMining : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        GetComponent<MeshCollider>().enabled = false;
    }

    void Update()
    {
        Mining();
    }

    //переделать под кирку (пока костыль чтобы проверить)
    private void Mining()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("attack", true);
            GetComponent<MeshCollider>().enabled = true;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("attack", false);
            GetComponent<MeshCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<OreForMining>() != null)
        {
            other.GetComponent<OreForMining>().HitByPickaxe();
        }
    }

    
}
