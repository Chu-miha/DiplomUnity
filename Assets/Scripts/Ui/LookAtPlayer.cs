using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    private void LateUpdate()
    {
        transform.LookAt(_camera);
    }
}
