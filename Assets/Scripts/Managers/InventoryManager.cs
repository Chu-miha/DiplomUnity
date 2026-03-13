using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    private Dictionary<string, List<ItemOre>> _itemsOre;

    public void Startup()
    {
        Debug.Log("Inventory manager starting...");
        _itemsOre = new Dictionary<string, List<ItemOre>>();
        status = ManagerStatus.Started;
    }

    //спроси
    private void DisplayItems()
    {
        string itemDisplay = "Items: ";
        foreach (KeyValuePair<string, List<ItemOre>> item in _itemsOre)
        {
            itemDisplay += item.Key  + " количество " + item.Value.Count + "(" + item.Value[0].Price + ")"; 
        }
        Debug.Log(itemDisplay);
    }

    public void AddItem(ItemOre item)
    {
        if (_itemsOre.ContainsKey(item.Name))
        {
            _itemsOre[item.Name].Add(item);
            
        }
        else
        {
            _itemsOre[item.Name] = new List<ItemOre> { item } ;
        }
        DisplayItems();
    }


}
