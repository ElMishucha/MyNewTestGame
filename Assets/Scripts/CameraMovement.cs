using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    public float cameraDistance;
    void addRay()
    {
        RaycastHit hit;

        Ray ray = new Ray(FindObjectOfType<PlayerMovement>().transform.position, new Vector3(43.278f, -27.456f + 180f, 0f));
        if (Physics.Raycast(ray, out hit, cameraDistance))
        {
            GetComponent<Transform>().position = hit.transform.position;
        }
        //Debug.DrawRay(FindObjectOfType<PlayerMovement>().transform.position, new Vector3(43.278f, -27.456f + 180f, 0f), Color.red, cameraDistance);

    }

    //43.278f -27.456f+180f 0f
    public Transform cameraPoint;

    public void FixedUpdate()
    {
        //addRay();
        transform.position = Vector3.Lerp(transform.position, cameraPoint.position + new Vector3(2.834f, 5.743f, -5.531f), Time.deltaTime * 5f);
    }
}
