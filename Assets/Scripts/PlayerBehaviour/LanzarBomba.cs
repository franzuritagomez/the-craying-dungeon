using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarBomba : MonoBehaviour
{

    public float f_fuerzaLanzamiento = 10f;
    public GameObject go_bomba;
    public Transform t_puntoLanzamiento;
    private Inventario inventario;

    private void Start()
    {
        inventario = GetComponent<Inventario>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventario.i_cantidadBomb == 0)
            {
                Debug.Log("No tienes bombas");
            }
            else
            {
                Lanzar();
                inventario.i_cantidadBomb -= 1;
            }
            
        }
    }

    private void Lanzar()
    {
        GameObject go_bombaCopia = Instantiate(go_bomba, t_puntoLanzamiento.position, t_puntoLanzamiento.rotation);
        Rigidbody rb = go_bombaCopia.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * f_fuerzaLanzamiento, ForceMode.VelocityChange);
        }
    }

}
