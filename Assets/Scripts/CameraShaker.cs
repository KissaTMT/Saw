using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public static CameraShaker instance;
    private CinemachineBasicMultiChannelPerlin _noise;

    private void Awake()
    {
        instance = this;
        _noise = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    public void Shake()
    {
       StartCoroutine(ShakeRoutine());
    }
    private IEnumerator ShakeRoutine()
    {
        _noise.m_AmplitudeGain = 1;
        _noise.m_FrequencyGain = 1;
        yield return new WaitForSeconds(0.25f);
        _noise.m_AmplitudeGain = 0;
        _noise.m_FrequencyGain = 0;
    }
}
