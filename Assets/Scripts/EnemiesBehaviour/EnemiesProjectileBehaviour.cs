using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesProjectileBehaviour : MonoBehaviour
{

    [Header("Stats")]
    public int i_damage;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject go_enemie = GameObject.FindGameObjectWithTag("Enemy");
        //Physics.IgnoreCollision(go_enemie.GetComponent<SphereCollider>(),
        //    GetComponent<SphereCollider>(), true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            player.RecibirDaño(i_damage);
            Destroy(gameObject);
            Debug.Log("Colisionado con el player");
        }

        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Door"))
        {
            Destroy(gameObject);
        }
    }
}
