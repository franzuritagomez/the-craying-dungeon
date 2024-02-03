using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    Inventario inventario;
    PlayerHealth playerHealth;
    PlayerShootingBehaviour shootingBehaviour;
    ProjectileBehaviour projectileBehaviour;
    PlayerMovement playerMovement;
    public static event Action OnCoinCollected;
    public static event Action OnKeyCollected;
    public static event Action OnBombCollected;
    public static event Action OnItemCollected;
    private CharacterController cc_player;

    // Start is called before the first frame update
    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
        cc_player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        shootingBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShootingBehaviour>();
        projectileBehaviour = GameObject.FindWithTag("Projectile").GetComponent<ProjectileBehaviour>();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        transform.LookAt(cc_player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Player"))
        {
            if (gameObject.tag.Equals("SimpleCoin"))
            {
                SimpleCoin();
            }
            if (gameObject.tag.Equals("SimpleKey"))
            {
                SimpleKey();
            }
            if (gameObject.tag.Equals("SimpleBomb"))
            {
                SimpleBomb();
            }
            if (gameObject.tag.Equals("LlaveTienda"))
            {
                LlaveTienda();
            }
            if (gameObject.tag.Equals("BombaTienda"))
            {
                BombaTienda();
            }
            if (gameObject.tag.Equals("SkeletonKey"))
            {
                SkeletonKey();
            }
            if (gameObject.tag.Equals("1up"))
            {
                OneUp();
            }
            if (gameObject.tag.Equals("AllStats"))
            {
                AllStats();
            }
            if (gameObject.tag.Equals("BloodOfTheMartir"))
            {
                BloodOfTheMartir();
            }
            if (gameObject.tag.Equals("CricketsHead"))
            {
                CricketsHead();
            }
            if (gameObject.tag.Equals("Dollar"))
            {
                Dollar();
            }
            if (gameObject.tag.Equals("PYRO"))
            {
                PYRO();
            }
            if (gameObject.tag.Equals("OneHeart"))
            {
                OneHeart();
            }
            if (gameObject.tag.Equals("Palillo"))
            {
                Palillo();
            }
            if (gameObject.tag.Equals("Pentagrama"))
            {
                Pentagrama();
            }
            if (gameObject.tag.Equals("Percha"))
            {
                Percha();
            }
            if (gameObject.tag.Equals("SadOnion"))
            {
                SadOnion();
            }
            if (gameObject.tag.Equals("Tienda_1up"))
            {
                OnItemCollected?.Invoke();
                playerHealth.RecibirDaño(4);
                OneUp();
            }
            if (gameObject.tag.Equals("Tienda_AllStats"))
            {
                AllStats();
                playerHealth.RecibirDaño(4);
            }
            if (gameObject.tag.Equals("Tienda_BloodOfTheMartirs"))
            {
                BloodOfTheMartir();
                playerHealth.RecibirDaño(4);

            }
            if (gameObject.tag.Equals("Tienda_CricketsHead"))
            {
                CricketsHead();
                playerHealth.RecibirDaño(4);

            }
            if (gameObject.tag.Equals("Tienda_Dollar"))
            {
                Dollar();
                playerHealth.RecibirDaño(4);

            }
            if (gameObject.tag.Equals("Tienda_OneHeart"))
            {
                OneHeart();
                playerHealth.RecibirDaño(4);

            }
            if (gameObject.tag.Equals("Tienda_Palillo"))
            {
                Palillo();
                playerHealth.RecibirDaño(4);
            }
            if (gameObject.tag.Equals("Tienda_Pentagrama"))
            {
                Pentagrama();
                playerHealth.RecibirDaño(4);

            }
            if (gameObject.tag.Equals("Tienda_Percha"))
            {
                Percha();
                playerHealth.RecibirDaño(4);

            }
            if (gameObject.tag.Equals("Tienda_PYRO"))
            {
                PYRO();
                playerHealth.RecibirDaño(4);

            }
            if (gameObject.tag.Equals("Tienda_SadOnion"))
            {
                SadOnion();
                playerHealth.RecibirDaño(4);

            }
            if (gameObject.tag.Equals("Tienda_SkeletonKey"))
            {
                SkeletonKey();
                playerHealth.RecibirDaño(4);
            }
        }
    }

    private void SimpleCoin()
    {
        OnCoinCollected?.Invoke();
        inventario.i_cantidadCoin = inventario.i_cantidadCoin + 1;
        Destroy(gameObject);
    }

    private void SimpleKey()
    {
        OnKeyCollected?.Invoke();
        inventario.i_cantidadKey = inventario.i_cantidadKey + 1;
        Destroy(gameObject);
    }

    private void SimpleBomb()
    {
        OnBombCollected?.Invoke();
        inventario.i_cantidadBomb = inventario.i_cantidadBomb + 1;
        Destroy(gameObject);
    }

    private void LlaveTienda()
    {
        if (inventario.i_cantidadCoin >= 3)
        {
            OnKeyCollected?.Invoke();
            inventario.i_cantidadKey = inventario.i_cantidadKey + 1;
            inventario.i_cantidadCoin -= 3;
        }
    }

    private void BombaTienda()
    {
        if (inventario.i_cantidadCoin >= 3)
        {
            OnBombCollected?.Invoke();
            inventario.i_cantidadBomb = inventario.i_cantidadBomb + 1;
            inventario.i_cantidadCoin -= 3;
        }
    }

    private void SkeletonKey()
    {
        OnItemCollected?.Invoke();
        inventario.i_cantidadKey = (99 - inventario.i_cantidadKey) + inventario.i_cantidadKey;
        Destroy(gameObject);
    }

    private void OneUp()
    {
        OnItemCollected?.Invoke();
        playerHealth.Regenerar();
        Destroy(gameObject);
    }

    private void AllStats()
    {
        OnItemCollected?.Invoke();
        playerHealth.Regenerar();
        if ((shootingBehaviour.timeBetweenShooting -= 0.25f) >= 0.1)
        {
            shootingBehaviour.timeBetweenShooting = shootingBehaviour.timeBetweenShooting - 0.25f;
        }
        else
        {
            shootingBehaviour.timeBetweenShooting = 0.1f;
        }
        shootingBehaviour.go_bullet.GetComponent<ProjectileBehaviour>().i_damage += 2;
        Destroy(gameObject);
    }

    private void BloodOfTheMartir()
    {
        OnItemCollected?.Invoke();
        shootingBehaviour.go_bullet.GetComponent<ProjectileBehaviour>().i_damage += 2;
        Destroy(gameObject);
    }

    private void CricketsHead()
    {
        OnItemCollected?.Invoke();
        shootingBehaviour.go_bullet.GetComponent<ProjectileBehaviour>().i_damage += 2;
        if ((shootingBehaviour.timeBetweenShooting -= 0.25f) >= 0.1)
        {
            shootingBehaviour.timeBetweenShooting = shootingBehaviour.timeBetweenShooting - 0.25f;
        }
        else
        {
            shootingBehaviour.timeBetweenShooting = 0.1f;
        }
        Destroy(gameObject);
    }

    private void Dollar()
    {
        OnItemCollected?.Invoke();
        inventario.i_cantidadCoin = (99 - inventario.i_cantidadCoin) + inventario.i_cantidadCoin;
        Destroy(gameObject);
    }

    private void PYRO()
    {
        OnItemCollected?.Invoke();
        inventario.i_cantidadBomb = (99 - inventario.i_cantidadBomb) + inventario.i_cantidadBomb;
        Destroy(gameObject);
    }

    private void OneHeart()
    {
        OnItemCollected?.Invoke();
        playerHealth.Regenerar();
        Destroy(gameObject);
    }

    private void Palillo()
    {
        OnItemCollected?.Invoke();
        if ((shootingBehaviour.timeBetweenShooting -= 0.1f) >= 0.1)
        {
            shootingBehaviour.timeBetweenShooting = shootingBehaviour.timeBetweenShooting - 0.25f;
        }
        else
        {
            shootingBehaviour.timeBetweenShooting = 0.1f;
        }
        Destroy(gameObject);
    }

    private void Pentagrama()
    {
        OnItemCollected?.Invoke();
        shootingBehaviour.go_bullet.GetComponent<ProjectileBehaviour>().i_damage += 30;
        Destroy(gameObject);
    }

    private void Percha()
    {
        OnItemCollected?.Invoke();
        if ((shootingBehaviour.timeBetweenShooting -= 0.25f) >= 0.1)
        {
            shootingBehaviour.timeBetweenShooting = shootingBehaviour.timeBetweenShooting - 0.25f;
        }
        else
        {
            shootingBehaviour.timeBetweenShooting = 0.1f;
        }
        Destroy(gameObject);
    }

    private void SadOnion()
    {
        OnItemCollected?.Invoke();
        if ((shootingBehaviour.timeBetweenShooting -= 0.25f) >= 0.1)
        {
            shootingBehaviour.timeBetweenShooting = shootingBehaviour.timeBetweenShooting - 0.25f;
        }
        else
        {
            shootingBehaviour.timeBetweenShooting = 0.1f;
        }
        Destroy(gameObject);
    }
}
