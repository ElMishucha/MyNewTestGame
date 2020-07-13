using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleMovement : MonoBehaviour
{
    public Transform playerTransform;
    void FixedUpdate()
    {
        transform.position = playerTransform.position + new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Transform newTransform = playerTransform;
        if (!FindObjectOfType<PlayerMovement>().isGrabbed && !FindObjectOfType<PlayerMovement>().gameOver)
        {
            newTransform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y + -27.456f, FindObjectOfType<PlayerMovement>().transform.eulerAngles.z);
        }
        transform.LookAt(newTransform);
    }
}
