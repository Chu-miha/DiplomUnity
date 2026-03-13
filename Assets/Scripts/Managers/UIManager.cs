using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public Text DialogText;
    public GameObject DialogPanel;

    [SerializeField] private Image StamBar;
    [SerializeField] private Image HpBar;
    [SerializeField] private Text uIPickUp;
    [SerializeField] private Text uINpcInterect;
    [SerializeField] private GameObject panelInventory;
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private Transform inventoryPanel;
    [SerializeField] private GameObject panelHpAndStam;
    [SerializeField] private List<InventorySlot> slots = new List<InventorySlot>();


    public void Startup()
    {
        Debug.Log("UI manager starting...");

        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            if (inventoryPanel.GetChild(i).GetComponents<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        MainManager.EventManager.onStaminaChange += UpdateStam;
        MainManager.EventManager.onHpChange += UpdateHp;
        MainManager.EventManager.onInventoryShow += ShowPanelInventory;
        MainManager.EventManager.onDialogActive += ShowDialog;
        MainManager.EventManager.onMenuActive += ShowMenu;
        uIPickUp.enabled = false;
        uINpcInterect.enabled = false;
        DialogText.text = string.Empty;
        DialogPanel.SetActive(false);
        panelMenu.SetActive(false);
        panelInventory.SetActive(false);
        status = ManagerStatus.Started;

    }

    public float ConvertToFillAmount(float amount)
    {
        float fillAmount = amount / 100;
        return fillAmount;
    }

    public void UpdateStam(float stamin)
    {
        StamBar.fillAmount = ConvertToFillAmount(stamin);
    }

    public void UpdateHp(float hp)
    {
        HpBar.fillAmount = ConvertToFillAmount(hp);
    }

    public void ShouPickUpUI()
    {
        uIPickUp.enabled = true;
    }

    public void DontShouPickUpUI() 
    {
        uIPickUp.enabled = false;
    }

    public void ShouNpcInterect(bool show)
    {
        uINpcInterect.enabled = show;
    }

    public void ShowPanelInventory(bool show)
    {
        panelInventory.SetActive(show);
        if (MainManager.WeaponsManager.currentWeaponInstance != null) MainManager.WeaponsManager.currentWeaponInstance.SetActive(!show);
    }

    public void ShowDialog(bool show)
    {
        DialogPanel.SetActive(show);
        panelHpAndStam.SetActive(!show);
        if(MainManager.WeaponsManager.currentWeaponInstance != null) MainManager.WeaponsManager.currentWeaponInstance.SetActive(!show);

    }

    public void ShowMenu(bool show)
    {
        panelMenu.SetActive(show);
        panelHpAndStam.SetActive(!show);
        if (MainManager.WeaponsManager.currentWeaponInstance != null) MainManager.WeaponsManager.currentWeaponInstance.SetActive(!show);

    }

    
    public void AddItem(Item item, int amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.Item == item)
            {
                slot.Amount += amount;
                slot.ItemAmount.text = slot.Amount.ToString();
                return;
            }
        }
        foreach (InventorySlot slot in slots)
        {
            if(slot.isEmpty == true)
            {
                slot.Item = item;
                slot.Amount = amount;
                slot.isEmpty = false;
                slot.SetIcon(item.Icon);
                slot.ItemAmount.text = slot.Amount.ToString();
                return;
            }
        }
    }

}
