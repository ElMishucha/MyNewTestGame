using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform target;
    public Rigidbody rb;
    public float speed;
    public float jumpForce;
    public Vector3 move;
    public bool isGrounded;
    public bool isGrabbed;
    public Transform grabPoint;
    public ParticleSystem ps;
    public bool dead;
    public bool gameOver;
    private bool rightDash;
    private bool leftDash;
    private float lastAngle;

    private void FixedUpdate()
    {
        /*//print(lastAngle);
        // dash
        if (Input.GetAxis("RightDash") > 0f)
        {
            print("rightDash");
            lastAngle = transform.eulerAngles.z;
            rightDash = true;
        }

        if (Input.GetAxis("LeftDash") > 0f)
        {
            print("leftDash");
            lastAngle = transform.eulerAngles.z;
            leftDash = true;
        }

        if (rightDash)
        {
            transform.Rotate(0f, 0f, 90f);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, lastAngle + 360f), Time.deltaTime * 5f);
            if (transform.eulerAngles.z == lastAngle + 90f)
            {
                rightDash = false;
            }
            rightDash = false;
        }

        if (leftDash)
        {
            transform.Rotate(0f, 0f, -90f);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, lastAngle -360f), Time.deltaTime * 5f);
            if (transform.eulerAngles.z == lastAngle - 90f)
            {
                leftDash = false;
            }
            leftDash = false;
        }*/


        // dead
        if (dead)
        {
            ps.Play();
            dead = false;
        }



        // movement
        if (!isGrabbed && !gameOver)
        {

            if (Input.GetAxis("Jump") > 0f && isGrounded)
            {
                rb.AddForce(jumpForce * transform.up);
            }
            //transform.LookAt(target);
            //transform.rotation = Quaternion.Euler(target.rotation.x, target.eulerAngles.y, target.rotation.z);
            if ((Mathf.RoundToInt(Input.GetAxis("Horizontal")) != 0f || Mathf.RoundToInt(Input.GetAxis("Vertical")) != 0f))
            {
                //transform.Rotate(0f, -27.456f, 0f);
                rb.MovePosition(transform.forward * Time.deltaTime * -speed + transform.position);
            }
        }


        // Farmer`s grab
        if (transform.position == grabPoint.position && transform.rotation == grabPoint.rotation || isGrabbed == true)
        {
            transform.position = grabPoint.position;
            transform.rotation = Quaternion.Euler(grabPoint.rotation.x, grabPoint.rotation.y, transform.rotation.z);
            rb.useGravity = false;
        }

    }

}


