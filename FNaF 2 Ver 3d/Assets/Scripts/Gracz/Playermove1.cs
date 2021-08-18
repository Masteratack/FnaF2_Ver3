using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crazy.Movement
{
    public class Playermove1 : MonoBehaviour
    {
        public CharacterController controller;

        public float speed = 12f;
        public float gravity = -10f;
        public float JumpHeight = 3f;

        public Transform GroundChecker;
        public float grounddistance = 0.4f;
        public LayerMask groundMask;
        Vector3 velocity;
        bool isGrounded;

        // Update is called once per frame
        void Update()
        {
            isGrounded = Physics.CheckSphere(GroundChecker.position, grounddistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;


            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}

