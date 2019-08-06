using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeMagnitude;
    [SerializeField] private float dampningSpeed;
    public static ShakeCamera ShakeCameraRef { private set; get; }
    private float timer;
    private Vector3 startPosition;
    private Transform cameraTransform;
    private void Awake()
    {
        if(ShakeCameraRef == null)
        {
            ShakeCameraRef = this;
        }
        cameraTransform = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        timer = shakeDuration;
    }
    private void Update()
    {
        if (timer > 0)
        {
            transform.localPosition = startPosition + Random.insideUnitSphere * shakeMagnitude;
            timer -= Time.deltaTime / dampningSpeed;
        }
        else
        {
            transform.localPosition = startPosition;
            timer = shakeDuration;
            enabled = false;
        }
    }
}
