using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController cc_player;
    public Transform t_groundCheck;
    public float f_speed = 12f;
    public float f_gravity = -9.81f;
    public float f_groundDistance = 0.4f;
    public float f_jumHeight = 2f;
    public LayerMask lm_groundMask;

    [SerializeField] float f_horizontal;
    [SerializeField] float f_vertical;
    Vector3 v3_velocity;
    bool b_isGrounded;

    // Update is called once per frame
    void Update()
    {
        b_isGrounded = Physics.CheckSphere(t_groundCheck.position, f_groundDistance, lm_groundMask);

        if (b_isGrounded && v3_velocity.y < 0)
        {
            v3_velocity.y = -2f;
        }

        f_horizontal = Input.GetAxis("Horizontal");
        f_vertical = Input.GetAxis("Vertical");

        Vector3 v3_move = transform.right * f_horizontal + transform.forward * f_vertical; // mover el player independientemente de donde esté mirando
    
        cc_player.Move(v3_move * f_speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && b_isGrounded)
        {
            v3_velocity.y = Mathf.Sqrt(f_jumHeight * -2f * f_gravity);
        }

        v3_velocity.y += f_gravity * Time.deltaTime;

        cc_player.Move(v3_velocity * Time.deltaTime);
    }
}
