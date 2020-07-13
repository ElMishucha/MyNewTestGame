using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerMovement : MonoBehaviour
{
    public bool win;

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
    private float now = 1f;
    public float released = 0f;
    public float maxToRelease;
    public Slider slider;
    public bool nowReleased;

    private void FixedUpdate()
    {
        if (!win)
        {
            /*if (released >= maxToRelease && gameOver == true)
            {
                gameOver = false;
                nowReleased = true;
            }
            if (gameOver == true)
            {
                slider.gameObject.SetActive(true);
                slider.value = released;
                if (Mathf.RoundToInt(Input.GetAxis("Dash")) == now)
                {
                    now = now * -1f;
                    released += 0.02f;
                }
                released -= 0.002f;
                released = Mathf.Clamp(released, 0f, maxToRelease);
            } else
            {
                slider.gameObject.SetActive(false);
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
                transform.rotation = Quaternion.Euler(grabPoint.eulerAngles.x, grabPoint.eulerAngles.y, transform.eulerAngles.z);
                rb.useGravity = false;
            }

        }
    }
}


