using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba_Explosiva : MonoBehaviour
{

    public float f_tiempo = 1f;
    public float f_cuentaAtras;
    public bool b_haExplotado = false;
    public GameObject go_EfectoExplosion;
    public float f_radio = 5f;
    public float f_fuerza = 700f;
    public int i_daño = 75;
    public static event Action OnBombExplosion;

    // Start is called before the first frame update
    void Start()
    {
        f_cuentaAtras = f_tiempo;
    }

    // Update is called once per frame
    void Update()
    {
        f_cuentaAtras -= Time.deltaTime;
        if (f_cuentaAtras <= 0f && b_haExplotado == false)
        {
            Explota();
            OnBombExplosion?.Invoke();
            b_haExplotado = true;
        }
    }

    private void Explota()
    {
        Instantiate(go_EfectoExplosion, transform.position, transform.rotation); //Instanciar animación

        Collider[] colliders = Physics.OverlapSphere(transform.position, f_radio); // Detectar los objectos cercanos a la bomba
        foreach (Collider objectsCercanos in colliders)
        {
            BasicEnemyHealth enemigo = objectsCercanos.GetComponent<BasicEnemyHealth>();
            PlayerHealth playerHealth = objectsCercanos.GetComponent<PlayerHealth>();
            if (enemigo != null)
            {
                enemigo.TakeDamage(i_daño);
            }
            if (playerHealth != null)
            {
                playerHealth.RecibirDaño(5);
            }
        }
        Destroy(gameObject);
    }
}
