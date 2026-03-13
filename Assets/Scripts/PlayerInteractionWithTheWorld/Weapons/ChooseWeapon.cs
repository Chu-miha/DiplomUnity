using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWeapon : MonoBehaviour
{
    [SerializeField] private KeyCode SelectKey;
    [SerializeField] private KeyCode SelectSecondKey;
    [SerializeField] private KeyCode DestroyKey;
    [SerializeField] private KeyCode ShowMenu;
    void Update()
    {
        if (Input.GetKeyDown(SelectKey))
        {
            MainManager.WeaponsManager.SelectWeapon(0);
        }
        else if (Input.GetKeyDown(SelectSecondKey))
        {
            MainManager.WeaponsManager.SelectWeapon(1);
        }
        if (Input.GetKeyDown(DestroyKey))
        {
            MainManager.WeaponsManager.DropWeapon(0);
        }
        else if (Input.GetKeyDown(ShowMenu)) 
        {
            MainManager.EventManager.InvokeMenuActive(true);
        }

    }
}
