using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    CharacterController cc_player;

    [Header("Opciones de Personaje")]
    public float f_walkSpeed = 6.0f;
    public float f_runSpeed = 10.0f;
    public float f_jumpSpeed = 8.0f;
    public float f_gravity = 20.0f;

    private Vector3 v3_move = Vector3.zero;

    void Start()
    {
        cc_player = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        if (cc_player.isGrounded)
        {
            v3_move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.LeftShift))
            {
                v3_move = transform.TransformDirection(v3_move) * f_runSpeed;
            }
            else
            {
                v3_move = transform.TransformDirection(v3_move) * f_walkSpeed;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                v3_move.y = f_jumpSpeed;
            }

        }
        v3_move.y -= f_gravity * Time.deltaTime;

        cc_player.Move(v3_move * Time.deltaTime);
    }
}
