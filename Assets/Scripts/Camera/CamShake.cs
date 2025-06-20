using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamShake : MonoBehaviour
{
    public CinemachineImpulseSource impulseSource;
    [SerializeField] private ScreenShakeProfile profile;
    private void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Shake()
    {
        Camera_Manager.instance.ScreenShakeFromProfile(profile, impulseSource);
    }
}
