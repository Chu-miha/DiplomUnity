using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item Item;
    public int Amount;
    public bool isEmpty = true;
    public Image Icon;
    public Text ItemAmount;

    private void Awake()
    {
        Icon = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        ItemAmount = transform.GetChild(0).GetChild(1).GetComponent<Text>();
    }

    public void SetIcon(Sprite icon)
    {
        Icon.color = new Color (1, 1, 1, 1);
        Icon.sprite = icon;
    }
}
