using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public delegate void OnStaminaChange(float stamina);
    public event OnStaminaChange onStaminaChange;

    public delegate void OnInventoryShow(bool show);
    public event OnInventoryShow onInventoryShow;

    public delegate void OnAttack(bool hide);
    public event OnAttack onAttack;

    public delegate void OnDialogActive(bool show);
    public event OnDialogActive onDialogActive;

    public delegate void OnHpChange(float hp);
    public event OnHpChange onHpChange;

    public delegate void OnMenuActive(bool show);
    public event OnMenuActive onMenuActive;

    public void Startup()
    {
        Debug.Log("Event manager starting...");
        status = ManagerStatus.Started;
        
    }

    public void InvokeStaminChange(float amount)
    {
        onStaminaChange?.Invoke(amount);
    }

    public void InvokeHpChange(float hp)
    {
        onHpChange?.Invoke(hp);
    }

    public void InvokeInventoryShow(bool show)
    {
        onInventoryShow?.Invoke(show);
    }

    public void InvokeAttack(bool attack)
    {
        onAttack?.Invoke(attack);
    }

    public void InvokeDialogActive(bool show)
    {
        onDialogActive?.Invoke(show);
    }

    public void InvokeMenuActive(bool show)
    {
        onMenuActive?.Invoke(show);
    }

}
