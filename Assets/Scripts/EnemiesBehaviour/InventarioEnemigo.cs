using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioEnemigo : MonoBehaviour
{
    public GameObject[] objetos;
    private Vector3 v3_spawn;

    public void SoltarObjetoRandom()
    {
        v3_spawn = new Vector3(gameObject.transform.position.x, 0f, gameObject.transform.position.z);
        int i_random = Random.Range(1, 10);
        if (i_random <= 5)
        {
            return;
        }
        if (i_random > 5 && i_random <= 6)
        {
            Instantiate(objetos[0], v3_spawn, transform.rotation);
        }
        if (i_random > 6 && i_random <= 7)
        {
            Instantiate(objetos[1], v3_spawn, transform.rotation);
        }
        if (i_random > 7 && i_random <=8)
        {
            Instantiate(objetos[2], v3_spawn, transform.rotation);
        }
        if (i_random > 9 && i_random <= 10)
        {
            Instantiate(objetos[3], v3_spawn, transform.rotation);
        }
        if (i_random >= 10)
        {
            Instantiate(objetos[4], v3_spawn, transform.rotation);
        }

    }

}
