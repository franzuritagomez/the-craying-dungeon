using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    // Arrays con las salas correspondientes
    public GameObject[] BottomRooms;
    public GameObject[] TopRooms;
    public GameObject[] LeftRooms;
    public GameObject[] RightRooms;

    // Lista para meter todas las salas
    public List<GameObject> rooms = new List<GameObject>();

    // Tiempo de espera, ya que en el start puede no existir la sala final
    public float i_tiempoEspera;
    private bool b_bossSpawneado;
    //public GameObject go_boss;
    public Transform t_salaBoss;

    private void Update()
    {
        if (i_tiempoEspera <= 0 && b_bossSpawneado == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    b_bossSpawneado = true;
                    t_salaBoss = rooms[i].transform;
                    //Instantiate(go_boss, t_salaBoss.transform.position);
                }
            }
        }
        else
        {
            i_tiempoEspera -= Time.deltaTime;
        }
    }

    // Método para añadir la sala a la lista
    public void AnadirSala(GameObject go_SalaNueva)
    {
        if (rooms.Count < 5 && rooms.Count > 50)
            return;

        rooms.Add(go_SalaNueva);
        go_SalaNueva.GetComponent<AddRooms>().GeneracionSalas();
    }
}
