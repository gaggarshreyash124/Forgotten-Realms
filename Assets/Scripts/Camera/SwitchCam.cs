using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCam : MonoBehaviour
{
   
    public CinemachineVirtualCamera playcam;
    public CinemachineVirtualCamera bosscam;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boss"))
        {
            Camera_Manager.SwitchCamera(bosscam);
        }
    }
}
