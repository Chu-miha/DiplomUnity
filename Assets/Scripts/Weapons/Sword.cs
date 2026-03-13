using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    Animator animator;
    private float currentStam;
    private bool canAttack;

    void Start()
    {
        animator = GetComponent<Animator>();
        GetComponent<MeshCollider>().enabled = false;
        canAttack = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && MainManager.PlayerManager.Stam >= weapon.UseStam)
        {
           StartCoroutine(Attack(canAttack));
        }
        
    }

    //private void Attack(bool attack)
    //{
    //        animator.SetBool("attack", attack);
    //        GetComponent<CapsuleCollider>().enabled = attack;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") 
        {
            other.GetComponent<Enemy>().TakeDamage(weapon.Damage);
        }
    }

    private IEnumerator Attack(bool attack)
    {
        if (attack)
        {
            canAttack = false;
            animator.SetBool("attack", attack);
            GetComponent<MeshCollider>().enabled = attack;
            //currentStam = MainManager.PlayerManager.Stam;
            //currentStam -= weapon.UseStam;
            MainManager.EventManager.InvokeStaminChange(MainManager.PlayerManager.Stam - weapon.UseStam);
            yield return new WaitForSeconds(0.5f);
            animator.SetBool("attack", false);
            GetComponent<MeshCollider>().enabled = false;
            canAttack = true;
        }
    }
}
