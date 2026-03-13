using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemInteraction 
{
    float DistanceToInteract { get; }

    void TriggerOnPlayerInteraction();
}
