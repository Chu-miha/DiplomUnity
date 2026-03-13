using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private KeyCode inventory;

    public bool showInventory;

    void Start()
    {
        showInventory = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inventory))
        {
            showInventory = !showInventory;
            MainManager.EventManager.InvokeInventoryShow(showInventory);
        }
    }
}
