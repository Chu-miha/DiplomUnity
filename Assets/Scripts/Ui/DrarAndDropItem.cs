using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrarAndDropItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private InventorySlot oldSlot;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        oldSlot = transform.GetComponentInParent<InventorySlot>();
    }

    //спросить про это 
    public void OnDrag(PointerEventData eventData)
    {
        if (oldSlot.isEmpty)
            return;
        GetComponent<RectTransform>().position += new Vector3(eventData.delta.x, eventData.delta.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (oldSlot.isEmpty)
            return;
        GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.75f);
        GetComponentInChildren<Image>().raycastTarget = false;
        transform.SetParent(transform.parent.parent);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (oldSlot.isEmpty)
            return;
        GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1f);
        GetComponentInChildren<Image>().raycastTarget = true;

        transform.SetParent(oldSlot.transform);
        transform.position = oldSlot.transform.position;
        if (eventData.pointerCurrentRaycast.gameObject.name == "PanelForInventory")
        {
            GameObject itemObject = Instantiate(oldSlot.Item.ItemPrefab, player.position + Vector3.up + player.forward, Quaternion.identity);
            itemObject.GetComponent<AddOre>().Amount = oldSlot.Amount;
            NullifySlotData();
        }
        else if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>() != null)
        {
            ExchangeSlotData(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>());
        }

    }

    void NullifySlotData()
    {
        oldSlot.Item = null;
        oldSlot.Amount = 0;
        oldSlot.isEmpty = true;
        oldSlot.Icon.color = new Color(1, 1, 1, 0);
        oldSlot.Icon.sprite = null;
        oldSlot.ItemAmount.text = "";
    }

    void ExchangeSlotData(InventorySlot newSlot)
    {
        Item item = newSlot.Item;
        int amount = newSlot.Amount;
        bool isEmpty = newSlot.isEmpty;
        Image iconGO = newSlot.Icon;
        Text itemAmountText = newSlot.ItemAmount;

        newSlot.Item = oldSlot.Item;
        newSlot.Amount = oldSlot.Amount;
        if (oldSlot.isEmpty == false)
        {
            newSlot.SetIcon(oldSlot.Icon.sprite);
            newSlot.ItemAmount.text = oldSlot.Amount.ToString();
        }
        else
        {
            newSlot.Icon.color = new Color(1, 1, 1, 0);
            newSlot.Icon.sprite = null;
            newSlot.ItemAmount.text = "";
        }

        newSlot.isEmpty = oldSlot.isEmpty;

        oldSlot.Item = item;
        oldSlot.Amount = amount;
        if (isEmpty == false)
        {
            oldSlot.SetIcon(iconGO.sprite);
            oldSlot.ItemAmount.text = amount.ToString();
        }
        else
        {
            oldSlot.Icon.color = new Color(1, 1, 1, 0);
            oldSlot.Icon.sprite = null;
            oldSlot.ItemAmount.text = "";
        }

        oldSlot.isEmpty = isEmpty;
    }

   
}
