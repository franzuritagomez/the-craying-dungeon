using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWallCollision : MonoBehaviour
{

    public int i_checkDirection;
    /**
     * 1 --> si hay que comprobar hacia ARRIBA (delante)
     * 2 --> si hay que comprobar hacia ABAJO (atrás)
     * 3 --> si hay que comprobar hacia la DERECHA 
     * 4 --> si hay que comprobar hacia la IZQUIERDA
     */
    public GameObject go_PrefabWallAuxiliar;

    private GameObject go_SalaCorregir;

    private void Start()
    {
        Invoke("CheckWalls", 0.5f);
    }


    public void CheckWalls()
    {
        // Invertivos el indice de la Layer para obtener una Mask de bits.
        // Sólo haría Raycast contra los colisionadores de la capa del go.
        int layerMask = 1 << gameObject.layer;

        // la ~ invierte el Raycast, colisiona con todo menos con la capa del go.
        layerMask = ~layerMask;

        RaycastHit hitInfo;

        if (i_checkDirection == 1)
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out hitInfo, 1f, layerMask))
            {
                if (hitInfo.transform.name.Equals("PuertaBL") || hitInfo.transform.name.Equals("PuertaRT"))
                {
                    return;
                }
                else
                {
                    go_SalaCorregir = transform.parent.parent.parent.gameObject;
                    go_PrefabWallAuxiliar.transform.position = new Vector3(0f + go_SalaCorregir.transform.position.x,
                        0 + go_SalaCorregir.transform.position.y, 9.5f + go_SalaCorregir.transform.position.z);
                    Instantiate(go_PrefabWallAuxiliar);
                    GameObject go_EntradaEliminar = transform.parent.gameObject;
                    Destroy(go_EntradaEliminar);
                }
            }
        }
        if (i_checkDirection == 2)
        {
            if (Physics.Raycast(transform.position, Vector3.back, out hitInfo, 1f, layerMask))
            {
                if (hitInfo.transform.name.Equals("PuertaBL") || hitInfo.transform.name.Equals("PuertaRT"))
                {
                    return;
                }
                else
                {
                    go_SalaCorregir = transform.parent.parent.parent.gameObject;
                    go_PrefabWallAuxiliar.transform.position = new Vector3(0f + go_SalaCorregir.transform.position.x,
                        0 + go_SalaCorregir.transform.position.y, -9.5f + go_SalaCorregir.transform.position.z);
                    Instantiate(go_PrefabWallAuxiliar);
                    GameObject go_EntradaEliminar = transform.parent.gameObject;
                    Destroy(go_EntradaEliminar);
                }
            }
        }
        if (i_checkDirection == 3)
        {
            if (Physics.Raycast(transform.position, Vector3.right, out hitInfo, 1f, layerMask))
            {
                if (hitInfo.transform.name.Equals("PuertaBL") || hitInfo.transform.name.Equals("PuertaRT"))
                {
                    return;
                }
                else
                {
                    go_SalaCorregir = transform.parent.parent.parent.gameObject;
                    go_PrefabWallAuxiliar.transform.position = new Vector3(9.5f + go_SalaCorregir.transform.position.x,
                        0 + go_SalaCorregir.transform.position.y, 0f + go_SalaCorregir.transform.position.z);
                    Instantiate(go_PrefabWallAuxiliar);
                    GameObject go_EntradaEliminar = transform.parent.gameObject;
                    Destroy(go_EntradaEliminar);
                }
            }
        }
        if (i_checkDirection == 4)
        {
            if (Physics.Raycast(transform.position, Vector3.left, out hitInfo, 1f, layerMask))
            {
                if (hitInfo.transform.name.Equals("PuertaBL") || hitInfo.transform.name.Equals("PuertaRT"))
                {
                    return;
                }
                else
                {
                    go_SalaCorregir = transform.parent.parent.parent.gameObject;
                    go_PrefabWallAuxiliar.transform.position = new Vector3(-9.5f + go_SalaCorregir.transform.position.x,
                        0 + go_SalaCorregir.transform.position.y, 0f + go_SalaCorregir.transform.position.z);
                    Instantiate(go_PrefabWallAuxiliar);
                    GameObject go_EntradaEliminar = transform.parent.gameObject;
                    Destroy(go_EntradaEliminar);
                }
            }
        }
    }
}
