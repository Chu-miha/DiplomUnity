using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ore", menuName = "ScpObject/Item/Ore")]
public class ItemOre : Item
{
    [SerializeField] private int _price;

    public int Price => this._price;
}
