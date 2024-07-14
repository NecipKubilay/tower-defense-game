using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class kameraKNTRL : MonoBehaviour
{
    public CinemachineFreeLook freeLook;

    void Start()
    {
        freeLook = GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right mouse button pressed
        {
            freeLook.enabled = !freeLook.enabled; // Toggle FreeLook on/off
        }
    }
}

