using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Slider HealthBar;
    [Range(0, 360)] public float ViewAngle = 90f;
    public float ViewDistance = 15f;
    public float DetectionDistance = 3f;
    public Transform EnemyEye;
    public Transform Target;
    public bool die;
    public float distanceForAttakPlayer;
    public float damage = 10;
    public NavMeshAgent Agent { get => agent; }
    public Path Path { get => path; }
    

    private StateMachineEnemy stateMachine;
    private NavMeshAgent agent;
    [SerializeField] private int hp;
    [SerializeField] private float breakAttak;
    private float delay = 0f;
    public string currentState;
    [SerializeField] private Path path;
    private Animator animator;
    private int currentAnimation;
    private List<string> animations;


    void Start()
    {
        stateMachine = GetComponent<StateMachineEnemy>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        stateMachine.Initialise();
        animations = new List<string>()
            {
                "Hit1",
                "Fall1",
                "Attack1h1",
            };
    }

    void Update()
    {
        HealthBar.value = hp;
        DrawViewState();
        
    }

    public void TakeDamage(int damageAmount)
    {
        hp -= damageAmount;
        Debug.Log("удар");
        StartHitAnim();

        if(hp <= 0) 
        {
            gameObject.SetActive(false);
            HealthBar.gameObject.SetActive(false);
        }
    }

    public bool IsInView()
    {
        float realAngle = Vector3.Angle(EnemyEye.forward, Target.position - EnemyEye.position);
        RaycastHit hit;
        if (Physics.Raycast(EnemyEye.transform.position, Target.position - EnemyEye.position, out hit, ViewDistance))
        {
            if (realAngle < ViewAngle / 2f && Vector3.Distance(EnemyEye.position, Target.position) <= ViewDistance && hit.transform == Target.transform)
            {
                return true;
            }
        }
        return false;
    }

    public void MoveToTarget()
    {
        agent.SetDestination(Target.position);
        animator.SetFloat("speedv", agent.speed);
    }

    private void DrawViewState()
    {
        Vector3 left = EnemyEye.position + Quaternion.Euler(new Vector3(0, ViewAngle / 2f, 0)) * (EnemyEye.forward * ViewDistance);
        Vector3 right = EnemyEye.position + Quaternion.Euler(-new Vector3(0, ViewAngle / 2f, 0)) * (EnemyEye.forward * ViewDistance);
        Debug.DrawLine(EnemyEye.position, left, Color.yellow);
        Debug.DrawLine(EnemyEye.position, right, Color.yellow);
    }

    public void AttakPlayer()
    {
        if ((delay += Time.deltaTime) > breakAttak)
        {
            StartAtackAnim();
            MainManager.EventManager.InvokeHpChange(MainManager.PlayerManager.Hp - damage);
            //Managers.Player.ChangeHealth(damage);
            //Managers.Canvas.ShowHp(Managers.Player.health);
            delay = 0f;
        }
    }

    public void StartWalkAnim()
    {
        animator.SetFloat("speedv", agent.speed);
    }

    public void StartAtackAnim()
    {
        animator.SetTrigger("Attack1h1");
    }

    public void StartHitAnim()
    {
        animator.SetTrigger("Hit1");
    }

    public void StartDieAnim()
    {
        animator.SetTrigger("Fall1");
    }

    public void ChangedSpeed(float speed)
    {
        agent.speed = speed;
    }

}



//public bool whoHeatMy;

//public void TakeDamage(int damage)
//{

//    healthEnemy -= damage;
//    if (healthEnemy <= 0)
//    {
//        Die();
//    }
//    Debug.Log(healthEnemy);
//    StartCoroutine(WhyYouBulitMe());
//}

//public void Die()
//{
//    if (die) return;
//    die = true;
//    Destroy(gameObject);
//}
//private IEnumerator WhyYouBulitMe()
//{
//    whoHeatMy = true;
//    yield return new WaitForSeconds(5f);
//    whoHeatMy = false;

//}


