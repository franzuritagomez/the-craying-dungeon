using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform t_playerCamera;
    public float f_maxDistance = 5; // Max. distancia donde puedes abrir la puerta

    private bool b_isOpened = false;
    private Animator anim;

    public static event Action OnOpenDoor;

    void Update()
    {
        // Esto dirá si el player ha presionado la tecla F
        if (Input.GetKeyDown(KeyCode.F))
        {
            Pressed();
        }
    }

    void Pressed()
    {
        //Esto llamará al Raycasthit y trandrá la información del objecto en el q ha hecho contacto
        RaycastHit doorhit;

        if (Physics.Raycast(t_playerCamera.transform.position, t_playerCamera.transform.forward, out doorhit, f_maxDistance))
        {
            // Si el raycast colisiona, checkea si ha colisionado con un objeto con el tag "DOOR"
            if (doorhit.transform.tag == "Door")
            {
                //Coge la animacion del padre del objeto del raycast
                anim = doorhit.transform.GetComponent<Animator>();

                b_isOpened = !b_isOpened;

                // Poner el bool true para activar la animación
                if (anim != null)
                {
                    anim.SetBool("b_isOpened", b_isOpened);
                    OnOpenDoor?.Invoke();
                }
                else
                {
                    anim.SetBool("b_isOpened", b_isOpened);
                }
                
                b_isOpened = !b_isOpened;
            }
        }
    }
}