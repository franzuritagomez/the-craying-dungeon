using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;
    public static event Action OnPlayerHealth;
    public static event Action OnPlayerMaxHealth;
    public GameObject go_GameOver;
    public AudioSource ad;

    public float f_health, f_maxHealth;

    public float get_f_health()
    {
        return f_health;
    } 
    public float get_f_maxHealth()
    {
        return f_maxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        f_health = f_maxHealth;
        ad = GameObject.Find("Canvas").GetComponent<AudioSource>();
    }

    
    public void RecibirDaño(float f_cantidad)
    {
        f_health -= f_cantidad; // Restarle la cantidad a la vida actual del player
        OnPlayerDamaged?.Invoke(); // Invokar evento para quitar corazones del UI

        if (f_health <= 0)
        {
            OnPlayerDeath?.Invoke();
            f_health = 0;
            GameOver();
        }
    }

    // función para invocar a la hora de haber recibido daño
    public void daño()
    {
        RecibirDaño(1);
    }

    public void AñadirVida(float f_cantidad)
    {
        f_health += f_cantidad; // Sumarle la cantidad a la health actual del player
        OnPlayerHealth?.Invoke();
    }


    public void RegeneraryAumentaMaxHealth(float f_cantidad)
    {
        f_maxHealth += f_cantidad; // Sumarle la cantidad a la maxHealth del player
    }

    public void Regenerar()
    {
        RegeneraryAumentaMaxHealth(2);
        float f_dif = f_maxHealth - f_health;
        AñadirVida(f_dif);
    }

    public void AumentaMaxHealth(float f_cantidad)
    {
        f_maxHealth += f_cantidad;
        OnPlayerMaxHealth?.Invoke();
    }

    public void vidaMax()
    {
        AumentaMaxHealth(2);
    }

    public void GameOver()
    {
        go_GameOver.SetActive(true);
        ad.Pause();
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
    }
}
