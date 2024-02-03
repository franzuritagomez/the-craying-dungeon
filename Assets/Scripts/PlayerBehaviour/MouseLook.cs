using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Opciones de Camara")]
    public float f_mouseSensitivity = 100f;
    public float f_minRotation = -90.0f;
    public float f_maxRotation = 90.0f;
    public float f_mouseX, f_mouseY;
    [SerializeField] private float f_xRotation = 0f;

    public Transform t_playerBody;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        f_mouseX = Input.GetAxis("Mouse X") * f_mouseSensitivity * Time.deltaTime; // Toma el valor del raotn en el Eje X
        f_mouseY = Input.GetAxis("Mouse Y") * f_mouseSensitivity * Time.deltaTime;  // Toma el valor del raotn en el Eje y

        f_xRotation -= f_mouseY;
        f_xRotation = Mathf.Clamp(f_xRotation, f_minRotation, f_maxRotation); // limitar los ángulos de movimiento de la cam

        transform.localRotation = Quaternion.Euler(f_xRotation, 0f, 0f); // rotar la camara. El eje x en negativo porq si no se rotan.

        t_playerBody.Rotate(Vector3.up * f_mouseX);
    }
}
