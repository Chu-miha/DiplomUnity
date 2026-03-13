using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public void ContineumGame()
    {
        MainManager.EventManager.InvokeMenuActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
