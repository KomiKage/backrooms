using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public AudioSource walkingSound;

    public PauseGame pg;

    public Animator cameraAnimator;

    private float speed = 5f;
    public float sprintMult = 1;
    public float gravity = -9.81f;

    Vector3 velocity;

        private void Update()
    {
        if (!pg.gamePaused)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * sprintMult * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                cameraAnimator.SetBool("isMoving", true);
                walkingSound.enabled = true;
            }
            else
            {
                cameraAnimator.SetBool("isMoving", false);
                walkingSound.enabled = false;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                sprintMult = 1.7f;
            }
            else
            {
                sprintMult = 1f;
            }
        }

        if (pg.gamePaused) { walkingSound.Stop(); }
        
    }
}
