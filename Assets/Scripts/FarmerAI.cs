using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerAI : MonoBehaviour
{
    public float rayDistance;
    public float speed;

    public Transform playerTransform;
    private Transform lastPlayerTransform;
    public Rigidbody rb;
    public Transform piggyHomeTransform;

    public float angleDistance;
    public int rays;

    private bool isNextToPiggy;

    public bool isFinded;

    int isFindedCounter = 0;
    float seconds = 0f;

    private void Start()
    {
        lastPlayerTransform = playerTransform;
    }
    void addRay(int i, float j)
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, new Vector3(transform.forward.x - angleDistance * (rays - 1) / 2 + i * angleDistance, transform.forward.y + j, transform.forward.z));
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.tag == "Player" && !FindObjectOfType<PlayerMovement>().isGrabbed)
            {
                // фермер увидел игрока
                //Vector3 direction = lastPlayerTransform.position - transform.position;
                //Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                //transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 15f);

                isFinded = true;
            }
        }

    }

    private void FixedUpdate()
    {
        if (isFinded)
        {
            lastPlayerTransform = playerTransform;
        }
        if (!FindObjectOfType<PlayerMovement>().isGrabbed)
        {
            if (transform.position != lastPlayerTransform.position &&
                    !FindObjectOfType<PlayerMovement>().isGrabbed &&
                    !FindObjectOfType<PlayerMovement>().gameOver)
            {
                rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
                Vector3 direction = lastPlayerTransform.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 15f);
            }
            // create farmer`s vision
            isFinded = false;
            for (int j = 0; j <= 8; j++)
            {
                for (int i = 0; i < rays; i++)
                {
                    addRay(i, j / 20f);
                }
            }
            if (!isFinded)
            {
                // farmer lost sight of the piggy
                // we must rotate left, then right
                //transform.eulerAngles = new Vector3(transform.eulerAngles.x, 
                //    Mathf.Lerp(transform.eulerAngles.y, transform.eulerAngles.y - 80f, Time.deltaTime * 5f),
                //    transform.eulerAngles.z);

            }
        }
        if (isNextToPiggy)
        {
            FindObjectOfType<PlayerMovement>().transform.position = Vector3.Lerp(playerTransform.position, FindObjectOfType<PlayerMovement>().grabPoint.position, Time.deltaTime * 5f);
            FindObjectOfType<PlayerMovement>().transform.rotation = Quaternion.Lerp(playerTransform.rotation, FindObjectOfType<PlayerMovement>().grabPoint.rotation, Time.deltaTime * 5f);
            //if (FindObjectOfType<PlayerMovement>().transform.position == FindObjectOfType<PlayerMovement>().grabPoint.transform.position &&
            //    FindObjectOfType<PlayerMovement>().transform.rotation == FindObjectOfType<PlayerMovement>().grabPoint.transform.rotation)
            //{
            FindObjectOfType<PlayerMovement>().isGrabbed = true;
            FindObjectOfType<PlayerMovement>().rb.useGravity = false;
            isNextToPiggy = false;
            //}
        }

        if (FindObjectOfType<PlayerMovement>().isGrabbed == true)
        {
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
            Vector3 direction = piggyHomeTransform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 15f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // farmer grabs the piggy
            isNextToPiggy = true;
        }
    }

}
