using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRooms : MonoBehaviour
{
    // Acceder al contenedor 
    private RoomTemplates templates;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.AnadirSala(gameObject);
    }

    // Método que comprueba y spawnea la sala
    public void GeneracionSalas()
    {
        RoomSpawner[] roomSpawners = GetComponentsInChildren<RoomSpawner>();
        foreach(RoomSpawner rSpawner in roomSpawners)
        {
            rSpawner.Spawn();
        }
    }

}
