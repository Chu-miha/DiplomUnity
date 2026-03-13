using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDelay
{
    private float _currentProjectTime;
    private float _interactTime;
    private float _delayTime;
    public InteractionDelay(float delayTime)
    {
        _delayTime = delayTime;
    }
    public void UpdateInteractTime(float interactTime)
    {
        _interactTime = interactTime;
    }
    public void UpdateProjectCurrentTime(float currentTime)
    {
        _currentProjectTime = currentTime;
    }

    public bool CanInteract()
    {
        return (_currentProjectTime >= _interactTime + _delayTime) ? true : false;
    }
}
