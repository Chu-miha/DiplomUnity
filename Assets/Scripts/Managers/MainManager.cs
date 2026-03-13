using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private List<IGameManager> _starsSequence;
    public static InventoryManager Inventory { get; private set; }
    public static EventManager EventManager { get; private set; }
    public static UIManager UIManager { get; private set; }
    public static PlayerManager PlayerManager { get; private set; }
    public static DialogManager DialogManager { get; private set; }
    public static WeaponsManager WeaponsManager { get; private set; }

    private void Awake()
    {
        Inventory = GetComponent<InventoryManager>();
        EventManager = GetComponent<EventManager>();
        UIManager = GetComponent<UIManager>();
        PlayerManager = GetComponent<PlayerManager>();
        DialogManager = GetComponent<DialogManager>();
        WeaponsManager = GetComponent<WeaponsManager>();

        _starsSequence = new List<IGameManager>
        {
            Inventory,
            EventManager,
            UIManager,
            PlayerManager,
            DialogManager,
            WeaponsManager
        };
        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        foreach (IGameManager manager in _starsSequence)
        {
            manager.Startup();
        }

        yield return null;

        int numModules = _starsSequence.Count;
        int numReady = 0;

        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;

            foreach (IGameManager manager in _starsSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }
            if (numReady > lastReady)
                Debug.Log("Progress: " + numReady + "/" + numModules);
            yield return null;
        }
        Debug.Log("All managers Started up");
    }
}
