using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform Player;
    private Vector3 distance;
    [Header("’Ç‚¢‚Â‚­ŽžŠÔ")] public float SmoothTime = 0.3f;
    private Vector3 Velocity = Vector3.zero;

    void Start()
    {
        distance = transform.position - Player.transform.position;
    }

    void Update()
    {
        Vector3 targetPosition = Player.transform.position + distance;

        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, new Vector3(targetPosition.x, targetPosition.y, targetPosition.z), ref Velocity, SmoothTime);

        transform.position = smoothPosition;
    }
}
