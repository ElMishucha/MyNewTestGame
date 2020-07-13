using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform cameraPoint;

    public void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cameraPoint.position + new Vector3(2.834f, 5.743f, -5.531f), Time.deltaTime * 5f);
    }
}
