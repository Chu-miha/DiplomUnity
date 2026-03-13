using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerObjectsInteract : MonoBehaviour
{
    [SerializeField] private KeyCode SelectKey;

    [SerializeField] private float InteractionDelayTime;

    InteractionDelay _interactionDelay;
    Camera _camera;

    private float _cameraCenterXPosition;

    private float _cameraCenterYPosition;

    public float Radius;

    private Vector3 _playerForward;

    private Ray _throwingRay;

    private RaycastHit _rayCastHit;

    private GameObject _hitObject;

    private IItemInteraction _itemsInteractionComponent;


    void Start()
    {
        _interactionDelay = new InteractionDelay(InteractionDelayTime);
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        _interactionDelay.UpdateProjectCurrentTime(Time.time);

        if (Input.GetKey(SelectKey))
        {
            if (_interactionDelay.CanInteract())
            {
                CatchItemObject();
            }
        }

        UpdatePickupIndicator();
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    private void CatchItemObject()
    {
        _cameraCenterXPosition = _camera.pixelWidth / 2;
        _cameraCenterYPosition = _camera.pixelHeight / 2;
        Vector3 origin = new Vector3(_cameraCenterXPosition, _cameraCenterYPosition, 0);
        _throwingRay = _camera.ScreenPointToRay(origin);
        if (Physics.SphereCast(_throwingRay, Radius, out _rayCastHit))
        {
            _hitObject = _rayCastHit.transform.gameObject;
            if ((_itemsInteractionComponent = _hitObject.GetComponent<IItemInteraction>()) != null)
            {
                if (_rayCastHit.distance <= _itemsInteractionComponent.DistanceToInteract)
                {
                    _itemsInteractionComponent.TriggerOnPlayerInteraction();
                    _interactionDelay.UpdateInteractTime(Time.time);
                }
            }
        }
    }

    private void UpdatePickupIndicator()
    {
        _cameraCenterXPosition = _camera.pixelWidth / 2;
        _cameraCenterYPosition = _camera.pixelHeight / 2;
        Vector3 origin = new Vector3(_cameraCenterXPosition, _cameraCenterYPosition, 0);
        _throwingRay = _camera.ScreenPointToRay(origin);

        if (Physics.SphereCast(_throwingRay, Radius, out _rayCastHit))
        {
            _hitObject = _rayCastHit.transform.gameObject;
            if ((_itemsInteractionComponent = _hitObject.GetComponent<IItemInteraction>()) != null)
            {
                if (_rayCastHit.distance <= _itemsInteractionComponent.DistanceToInteract)
                {
                    MainManager.UIManager.ShouPickUpUI();
                    return;
                }
            }
        }
        MainManager.UIManager.DontShouPickUpUI();
    }
}
