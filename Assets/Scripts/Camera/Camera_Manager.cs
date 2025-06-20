using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Sirenix.OdinInspector;

public class Camera_Manager : MonoBehaviour
{
    public static Camera_Manager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    [SerializeField] private float globalShakeforce = 1.0f;
    [SerializeField] private CinemachineImpulseListener impulseListener;

    public CinemachineImpulseDefinition ImpulseDefenition;


    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    public static CinemachineVirtualCamera ActiveCamera = null;

    public static bool IsActiveCamera(CinemachineVirtualCamera camera)
    {
        return camera == ActiveCamera;
    }

    public static void SwitchCamera(CinemachineVirtualCamera newcamera)
    {
        newcamera.Priority = 10;
        ActiveCamera = newcamera;

        foreach (CinemachineVirtualCamera cam in cameras)
        {
            if(cam != newcamera)
            {
                cam.Priority = 0;
            }
        }
    }
    public static void Register(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
    }

    public static void Unregister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
    }

    [Button("ShakeScreen")]
    public void CameraShake(CinemachineImpulseSource impluseSource)
    {
        impluseSource.GenerateImpulseWithForce(globalShakeforce);
    }

    public void ScreenShakeFromProfile(ScreenShakeProfile profile, CinemachineImpulseSource impulseSource)
    {
        //applying settings
        SetupScreenShakeSettings(profile, impulseSource);

        //screenshake
        impulseSource.GenerateImpulseWithForce(profile.impactForce);
    }

    private void SetupScreenShakeSettings(ScreenShakeProfile profile, CinemachineImpulseSource impulseSource)
    {
        ImpulseDefenition = impulseSource.m_ImpulseDefinition;

        // change the impulse source settings
        ImpulseDefenition.m_ImpulseDuration = profile.impactTime;
        impulseSource.m_DefaultVelocity = profile.defaultVelocity;
        ImpulseDefenition.m_CustomImpulseShape = profile.impulseCurve;

        //change the impulse Listerner settings
        impulseListener.m_ReactionSettings.m_AmplitudeGain = profile.listenerAmplitude;
        impulseListener.m_ReactionSettings.m_FrequencyGain = profile.listenerFrequency;
        impulseListener.m_ReactionSettings.m_Duration = profile.listenerDuration;
    }
}
