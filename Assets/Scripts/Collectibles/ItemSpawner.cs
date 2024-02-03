using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject go_itemSpawnPoint;
    public GameObject[] go_item;
    public int i_itemCount;

    [Header("Datos Privados")]
    [SerializeField] private float f_xPos;
    [SerializeField] private float f_zPos;
    [SerializeField] private float f_yPos;

    private void Start()
    {
        f_xPos = go_itemSpawnPoint.transform.position.x; // Coger la posicion en el eje X del punto de Spawn
        f_zPos = go_itemSpawnPoint.transform.position.z; // Coger la posicion en el eje Z del punto de Spawn
        f_yPos = go_itemSpawnPoint.transform.position.y; // Coger la posicion en el eje Y del punto de Spawn
        StartCoroutine(ItemSpawn());
    }

    IEnumerator ItemSpawn()
    {
        int i_random = 0;
        while (i_itemCount < 1)
        {
            GameObject go_Copy;
            i_random = Random.Range(0, 10);
            if (i_random == 0)
            {
                go_Copy = go_item[0];
            }
            else if (i_random == 1)
            {
                go_Copy = go_item[1];
            }
            else if (i_random == 2)
            {
                go_Copy = go_item[2];
            }
            else if (i_random == 3)
            {
                go_Copy = go_item[3];
            }
            else if (i_random == 4)
            {
                go_Copy = go_item[4];
            }
            else if (i_random == 5)
            {
                go_Copy = go_item[5];
            }
            else if (i_random == 6)
            {
                go_Copy = go_item[6];
            }
            else if (i_random == 7)
            {
                go_Copy = go_item[7];
            }
            else if (i_random == 8)
            {
                go_Copy = go_item[8];
            }
            else if (i_random == 9)
            {
                go_Copy = go_item[9];
            }
            else if (i_random == 10)
            {
                go_Copy = go_item[10];
            }
            else
            {
                go_Copy = go_item[11];
            }
            Instantiate(go_Copy, new Vector3(f_xPos, f_yPos, f_zPos), Quaternion.identity); // Instanciar GO en la posicion random dentro del a sala.
            yield return new WaitForSeconds(0.2f);
            i_itemCount++;
        }
    }

}
