using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    [SerializeField] private string _name;

    [SerializeField] private string _description;
    [SerializeField] private ItemType _itemType;
    public int Amount;

    public GameObject ItemPrefab;
    public Sprite Icon;
    public string Name => this._name;

    public string Description => this._description;
    public ItemType Type => this._itemType;
    
    

    
    
}
