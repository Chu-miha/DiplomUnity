using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNPCInterect : MonoBehaviour
{
    [SerializeField] private KeyCode SelectKey;

    private Camera _camera;

    private float cameraCenterXPosition;

    private float cameraCenterYPosition;

    public float Radius;

    private Ray throwingRay;

    private RaycastHit rayCastHit;

    private GameObject hitObject;

    private INPCInteraction npcInteractionComponent;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {

        if (Input.GetKeyDown(SelectKey))
        {
                InterectWithNpc();
        }

        UpdateInterectWithNpcIndicator();
    }


    private void InterectWithNpc()
    {
        cameraCenterXPosition = _camera.pixelWidth / 2;
        cameraCenterYPosition = _camera.pixelHeight / 2;
        Vector3 origin = new Vector3(cameraCenterXPosition, cameraCenterYPosition, 0);
        throwingRay = _camera.ScreenPointToRay(origin);
        if (Physics.SphereCast(throwingRay, Radius, out rayCastHit))
        {
            hitObject = rayCastHit.transform.gameObject;
            if ((npcInteractionComponent = hitObject.GetComponent<INPCInteraction>()) != null)
            {
                if (rayCastHit.distance <= npcInteractionComponent.DistanceToInteract)
                {
                    npcInteractionComponent.TriggerOnPlayerInteractionWithNpc();
                    
                }
            }
        }
    }

    private void UpdateInterectWithNpcIndicator()
    {
        cameraCenterXPosition = _camera.pixelWidth / 2;
        cameraCenterYPosition = _camera.pixelHeight / 2;
        Vector3 origin = new Vector3(cameraCenterXPosition, cameraCenterYPosition, 0);
        throwingRay = _camera.ScreenPointToRay(origin);

        if (Physics.SphereCast(throwingRay, Radius, out rayCastHit))
        {
            hitObject = rayCastHit.transform.gameObject;
            if ((npcInteractionComponent = hitObject.GetComponent<INPCInteraction>()) != null)
            {
                if (rayCastHit.distance <= npcInteractionComponent.DistanceToInteract)
                {
                    MainManager.UIManager.ShouNpcInterect(true);
                    return;
                }
            }
        }
        MainManager.UIManager.ShouNpcInterect(false);
    }


}
