using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject go_enemySpawnPoint;
    public GameObject[] go_enemy;
    public int i_enemyCount;

    [Header("Datos Privados")]
    [SerializeField] private float f_xPos;
    [SerializeField] private float f_zPos;


    private void Start()
    {
        f_xPos = go_enemySpawnPoint.transform.position.x; // Coger la posicion en el eje X del punto de Spawn
        f_zPos = go_enemySpawnPoint.transform.position.z; // Coger la posicion en el eje X del punto de Spawn
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        int i_random = 0;
        while (i_enemyCount < 5)
        {
            GameObject go_enemyCopy;
            i_random = Random.Range(0, 4);
            float f_xPosRand = f_xPos + Random.Range(-1f, 2f); // Número random teniendo en cuenta la pos del punto de Spawn
            float f_zPosRand = f_zPos + Random.Range(-1f, 2f);
            if (i_random == 0)
            {
                go_enemyCopy = go_enemy[0];
            }
            else if (i_random == 1)
            {
                go_enemyCopy = go_enemy[1];
            }
            else if (i_random == 2)
            {
                go_enemyCopy = go_enemy[2];
            }
            else if (i_random == 3)
            {
                go_enemyCopy = go_enemy[3];
            }
            else
            {
                go_enemyCopy = go_enemy[4];
            }
            Instantiate(go_enemyCopy, new Vector3(f_xPosRand, 1f, f_zPosRand), Quaternion.identity); // Instanciar GO en la posicion random dentro del a sala.
            yield return new WaitForSeconds(0.2f);
            i_enemyCount++;
        }
    }
}
