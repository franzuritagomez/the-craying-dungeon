using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [Header("Stats")]
    public int i_damage;

    private Rigidbody rb;
    private CharacterController cc;

    private bool b_targetHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.velocity = transform.TransformVector(Vector3.forward * 10f);
        GameObject go_player = GameObject.FindGameObjectWithTag("Player");
        Physics.IgnoreCollision(go_player.GetComponent<CharacterController>(),
            GetComponent<SphereCollider>());
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Comprobar que hemos dado a un enemigo
        if (collision.gameObject.GetComponent<BasicEnemyHealth>() != null)
        {
            BasicEnemyHealth enemy = collision.gameObject.GetComponent<BasicEnemyHealth>();
            enemy.TakeDamage(i_damage);
            Destroy(gameObject);
        }

        // Comprobar que hemos dado a un enemigo
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Wall") 
            || collision.gameObject.CompareTag("Door") || collision.gameObject.CompareTag("Roca") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
