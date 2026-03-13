using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    [SerializeField] private float hp;
    [SerializeField] private float maxHp;
    [SerializeField] private float stam;
    [SerializeField] private float maxStam;
    [SerializeField] private int coins;

    public float Hp { get { return hp; }}
    public float Stam { get { return stam; }}
    public int Coins { get { return coins; }}   

    public void Startup()
    {
        Debug.Log("Player manager starting...");
        MainManager.EventManager.onStaminaChange += ChangeStam;
        MainManager.EventManager.onHpChange += ChangeHp;
        status = ManagerStatus.Started;
    }

    public void ChangeHp(float count)
    {
        hp = count;
    }

    public void ChangeStam(float count)
    {
        stam = count;
    }

    public void ChangeCoins(int count)
    {
        coins = count;
    }


}
