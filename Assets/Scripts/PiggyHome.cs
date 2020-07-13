using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyHome : MonoBehaviour
{
    public Transform sitPoint;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerMovement>().isGrabbed = false;
            other.gameObject.transform.position = Vector3.Lerp(other.gameObject.transform.position, sitPoint.transform.position, Time.deltaTime * 5f);
            other.gameObject.transform.rotation = Quaternion.Lerp(other.gameObject.transform.rotation, sitPoint.transform.rotation, Time.deltaTime * 5f);
            FindObjectOfType<PlayerMovement>().gameOver = true;
        }
    }
}
