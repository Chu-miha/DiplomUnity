using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWeapon : MonoBehaviour, IItemInteraction
{
    public float DistanceToInteract
    {
        get
        {
            return distanceFromInteract;
        }
    }

    [SerializeField] float distanceFromInteract;
    [SerializeField] private Weapon weapon;

    // Update is called once per frame
    public void TriggerOnPlayerInteraction()
    {
        MainManager.WeaponsManager.AddWeaponPrefab(weapon);
        Destroy(gameObject);
        
    }
}
