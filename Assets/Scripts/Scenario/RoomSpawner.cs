using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int i_openingDirection;
    /**
     * 1 --> necesita una sala con la puerta ABAJO(bottom)
     * 2 --> necesita una sala con la puerta ARRIBA(top)
     * 3 --> necesita una sala con la puerta IZQUIERDA(left)
     * 4 --> necesita una sala con la puerta DERECHA(right)
     */


    public void Spawn()
    {
        // Comprueba si ya hay una sala instanciada
        if (Physics.Raycast(transform.position, Vector3.down))
        {
            Destroy(gameObject);
            return;
        }

        // Acceder al contenedor de salas
        RoomTemplates templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        if (i_openingDirection == 1)
        {
            int i_rand = Random.Range(0, templates.BottomRooms.Length);
            Instantiate(templates.BottomRooms[i_rand], transform.position + Vector3.down * 2, templates.BottomRooms[i_rand].transform.rotation);
        }
        else if (i_openingDirection == 2)
        {
            int i_rand = Random.Range(0, templates.TopRooms.Length);
            Instantiate(templates.TopRooms[i_rand], transform.position + Vector3.down * 2, templates.TopRooms[i_rand].transform.rotation);
        }
        else if (i_openingDirection == 3)
        {
            int i_rand = Random.Range(0, templates.LeftRooms.Length);
            Instantiate(templates.LeftRooms[i_rand], transform.position + Vector3.down * 2, templates.LeftRooms[i_rand].transform.rotation);
        }
        else if (i_openingDirection == 4)
        {
            int i_rand = Random.Range(0, templates.RightRooms.Length);
            Instantiate(templates.RightRooms[i_rand], transform.position + Vector3.down * 2, templates.RightRooms[i_rand].transform.rotation);
        }
        Destroy(gameObject);
    }
}
