using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 cameraOffset;

    public float speed = 5;
    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(player.position, desiredPosition, speed);
        transform.position = smoothedPosition;
    }
}
