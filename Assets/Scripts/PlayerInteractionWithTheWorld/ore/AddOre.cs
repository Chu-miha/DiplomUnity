using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOre : MonoBehaviour, IItemInteraction
{
    public float DistanceToInteract
    {
        get
        {
            return distanceFromInteract;
        }
    }
    [SerializeField] float distanceFromInteract;
    [SerializeField] private ItemOre _item;
    public int Amount;

    private void Awake()
    {
        Amount = _item.Amount;
    }

    // Update is called once per frame
    public void TriggerOnPlayerInteraction()
    {
        MainManager.Inventory.AddItem(_item);
        MainManager.UIManager.AddItem(_item, Amount);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name =="Trade") 
        {
            MainManager.PlayerManager.ChangeCoins(MainManager.PlayerManager.Coins + (_item.Price * Amount));
            Debug.Log(MainManager.PlayerManager.Coins);
            Destroy(gameObject);
        }
    }
}
