using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    public static event Action OnHeartCollected;
    public Transform t_player;
    private Inventario inventario;

    private void Start()
    {
        t_player = GameObject.Find("Cylinder").transform;
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }

    private void Update()
    {
        transform.LookAt(t_player);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            float f_health = playerHealth.get_f_health();
            float f_maxHealth = playerHealth.get_f_maxHealth();

            if (gameObject.tag.Equals("HalfHeart"))
            {
                if ((f_maxHealth - f_health) == 0)
                {
                    return;
                }
                else
                {
                    OnHeartCollected?.Invoke();
                    playerHealth.AñadirVida(1);
                    Destroy(gameObject);
                }

            }
            if (gameObject.tag.Equals("FullHeart"))
            {
                if ((f_maxHealth - f_health) == 0)
                {
                    return;
                }
                else if ((f_maxHealth - f_health) == 1)
                {
                    OnHeartCollected?.Invoke();
                    playerHealth.AñadirVida(1);
                    Destroy(gameObject);
                }
                else
                {
                    OnHeartCollected?.Invoke();
                    playerHealth.AñadirVida(2);
                    Destroy(gameObject);
                }
            }
            if (gameObject.tag.Equals("DobleFullHeartShop"))
            {
                if ((f_maxHealth - f_health) == 0)
                {
                    return;
                }
                else
                {
                    if (inventario.i_cantidadCoin >= 5)
                    {
                        inventario.i_cantidadCoin -= 5;
                        if ((f_maxHealth - f_health) == 1)
                        {
                            OnHeartCollected?.Invoke();
                            playerHealth.AñadirVida(1);
                        }
                        else if ((f_maxHealth - f_health) == 2)
                        {
                            OnHeartCollected?.Invoke();
                            playerHealth.AñadirVida(2);
                        }
                        else if ((f_maxHealth - f_health) == 3)
                        {
                            OnHeartCollected?.Invoke();
                            playerHealth.AñadirVida(3);
                        }
                        else
                        {
                            OnHeartCollected?.Invoke();
                            playerHealth.AñadirVida(4);
                        }
                    }
                    else
                    {
                        Debug.Log("No tienes monedas");
                    }
                }
            }
        }
    }
}

