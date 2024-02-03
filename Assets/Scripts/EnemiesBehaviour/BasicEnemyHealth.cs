using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealth : MonoBehaviour
{

    [Header("Stats")]
    public int i_health;

    public GameObject go_bomba;

    InventarioEnemigo inventario;

    public static event Action OnEnemyDead;

    private void Start()
    {
        inventario = GetComponent<InventarioEnemigo>();
    }

    public void TakeDamage(int i_damage)
    {
        i_health -= i_damage;

        if (i_health <= 0)
        {
            OnEnemyDead!.Invoke();
            Destroy(gameObject);
            inventario.SoltarObjetoRandom();
            if (gameObject.name.Contains("kidmutantbomb"))
            {
                Vector3 v3_spawn = new Vector3(gameObject.transform.position.x, 1f, gameObject.transform.position.z);
                Instantiate(go_bomba, v3_spawn, transform.rotation);
            }
        }
    }
}
