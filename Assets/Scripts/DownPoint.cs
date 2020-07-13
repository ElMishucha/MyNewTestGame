using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPoint : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8 ||
            other.gameObject.layer == 14)
        {
            FindObjectOfType<PlayerMovement>().isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8 ||
            other.gameObject.layer == 14)
        {
            FindObjectOfType<PlayerMovement>().isGrounded = false;
        }
    }
}
