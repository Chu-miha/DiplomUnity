using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public Transform weaponSpawnPoint;
    //костыль
    public Transform Parent;

    private List<Weapon> weaponPrefabs = new List<Weapon>();
    public GameObject currentWeaponInstance;


    public void Startup()
    {
        Debug.Log("Weapons manager starting...");
        status = ManagerStatus.Started;
    }

     public void AddWeaponPrefab(Weapon weaponPrefab)
    {
        weaponPrefabs.Add(weaponPrefab);
    }

    public void SelectWeapon(int weaponIndex)
    {
        if (weaponIndex < 0 || weaponIndex >= weaponPrefabs.Count)
        {
            Debug.Log("Invalid weapon index.");
            return;
        }

        if (currentWeaponInstance != null)
        {
            Destroy(currentWeaponInstance);
        }

        //currentWeaponInstance.transform.SetParent(weaponSpawnPoint, false);
        //currentWeaponInstance = Instantiate(weaponPrefabs[weaponIndex].UsedWeaponPrefab, weaponSpawnPoint.position, weaponSpawnPoint.rotation);
        currentWeaponInstance = Instantiate(weaponPrefabs[weaponIndex].UsedWeaponPrefab);
        currentWeaponInstance.transform.SetParent(weaponSpawnPoint, false);
        currentWeaponInstance.transform.localPosition = Vector3.zero;
        //currentWeaponInstance.transform.localRotation = Quaternion.identity;

    }

    public bool HasWeaponPrefab(Weapon weaponPrefab)
    {
        return weaponPrefabs.Contains(weaponPrefab);
    }

    public void DropWeapon(Weapon weaponPrefab)
    {
        if (weaponPrefabs.Contains(weaponPrefab))
        {
            if (currentWeaponInstance != null && currentWeaponInstance == weaponPrefab)
            {
                Instantiate(weaponPrefab.WeaponPrefab, weaponSpawnPoint.position, weaponSpawnPoint.rotation);
                currentWeaponInstance = null;
            }

            weaponPrefabs.Remove(weaponPrefab);
        }
    }

    // костыль, с верху лучше 
    public void DropWeapon(int weaponIndex)
    {
        if (currentWeaponInstance != null)
        {
            Destroy(currentWeaponInstance);
            currentWeaponInstance = null;
        }
        Instantiate(weaponPrefabs[weaponIndex].WeaponPrefab, weaponSpawnPoint.position, weaponSpawnPoint.rotation);
        weaponPrefabs.Remove(weaponPrefabs[weaponIndex]);

    }



 }
