using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public static ShakeCamera ShakeCameraRef { private set; get; }
    private Camera mainCam;
    private float shakeAmount;
    private void Awake()
    {
        if(ShakeCameraRef == null)
        {
            ShakeCameraRef = this;
        }
        if(mainCam == null)
        {
            mainCam = Camera.main;
        }
    }
    public void Shake(float amt, float lenght)
    {
        shakeAmount = amt;

        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", lenght);
    }

    private void BeginShake()
    {
        if(shakeAmount > 0)
        {
            Vector3 camPos = mainCam.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.y = offsetY;
            camPos.x = offsetX;

            mainCam.transform.position = camPos;        
        }
    }

    private void StopShake()
    {
        CancelInvoke("BeginShake");
        mainCam.transform.localPosition = Vector3.zero;
    }
}
