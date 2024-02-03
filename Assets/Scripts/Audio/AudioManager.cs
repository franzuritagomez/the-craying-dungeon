using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource audioSource;

    [SerializeField] AudioClip coinAudio;
    [SerializeField] AudioClip keyAudio;
    [SerializeField] AudioClip bombAudio;
    [SerializeField] AudioClip heartAudio;
    [SerializeField] AudioClip damageAudio1;
    [SerializeField] AudioClip damageAudio2;
    [SerializeField] AudioClip damageAudio3;
    [SerializeField] AudioClip playerDeathAudio;
    [SerializeField] AudioClip explosionAudio;
    [SerializeField] AudioClip enemyDeathAudio;
    [SerializeField] AudioClip playerShootAudio;
    [SerializeField] AudioClip enemyShootAudio;
    [SerializeField] AudioClip itemCollectedAudio;
    [SerializeField] AudioClip abrirPuerta;
    [SerializeField] AudioClip cerrarPuerta;


    private void OnEnable()
    {
        Interact.OnCoinCollected += PlayCoinSound;
        Interact.OnKeyCollected += PlayKeySound;
        Interact.OnBombCollected += PlayBombSound;
        AddHealth.OnHeartCollected += PlayHeartSound;
        PlayerHealth.OnPlayerDamaged += PlayerDamageSound;
        PlayerHealth.OnPlayerDeath += PlayerDeathSound;
        Bomba_Explosiva.OnBombExplosion += ExplosionSound;
        BasicEnemyHealth.OnEnemyDead += EnemyDeadSound;
        PlayerShootingBehaviour.OnPlayerShoot += PlayerShootSound;
        EnemyAI_Behaviour.OnEnemyShoot += EnemyShootSound;
        Interact.OnItemCollected += ItemCollectedSound;
        CheckPlayerEntered.OnClosedDoor += CerrarPuertaSound;
        CheckPlayerEntered2.OnClosedDoor += CerrarPuertaSound;
        CheckEnemyInRoom.OnOpenDoor += AbrirPuertaSound;
        CheckEnemyInRoom2.OnOpenDoor += AbrirPuertaSound;
        Door.OnOpenDoor += AbrirPuertaSound;

    }
    private void OnDisable()
    {
        Interact.OnCoinCollected -= PlayCoinSound;
        Interact.OnKeyCollected -= PlayKeySound;
        Interact.OnBombCollected -= PlayBombSound;
        AddHealth.OnHeartCollected -= PlayHeartSound;
        PlayerHealth.OnPlayerDamaged -= PlayerDamageSound;
        PlayerHealth.OnPlayerDeath -= PlayerDeathSound;
        Bomba_Explosiva.OnBombExplosion -= ExplosionSound;
        BasicEnemyHealth.OnEnemyDead -= EnemyDeadSound;
        PlayerShootingBehaviour.OnPlayerShoot -= PlayerShootSound;
        EnemyAI_Behaviour.OnEnemyShoot -= EnemyShootSound;
        Interact.OnItemCollected -= ItemCollectedSound;
        CheckPlayerEntered.OnClosedDoor -= CerrarPuertaSound;
        CheckPlayerEntered2.OnClosedDoor -= CerrarPuertaSound;
        CheckEnemyInRoom.OnOpenDoor -= AbrirPuertaSound;
        CheckEnemyInRoom2.OnOpenDoor -= AbrirPuertaSound;
        Door.OnOpenDoor -= AbrirPuertaSound;
    }

    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(coinAudio);
    }

    public void PlayKeySound()
    {
        audioSource.PlayOneShot(keyAudio);
    }

    public void PlayBombSound()
    {
        audioSource.PlayOneShot(bombAudio);
    }

    public void PlayHeartSound()
    {
        audioSource.PlayOneShot(heartAudio);
    }

    public void PlayerDamageSound()
    {
        float f_randomNum = Random.Range(0f, 10f);
        if (f_randomNum <= 3.33f)
        {
            audioSource.PlayOneShot(damageAudio1);
        }
        else if (f_randomNum > 3.33f && f_randomNum < 6.33f)
        {
            audioSource.PlayOneShot(damageAudio2);
        }
        else
        {
            audioSource.PlayOneShot(damageAudio3);
        }
    }

    public void PlayerDeathSound()
    {
        audioSource.PlayOneShot(playerDeathAudio);
    }

    public void ExplosionSound()
    {
        audioSource.PlayOneShot(explosionAudio);
    }

    public void EnemyDeadSound()
    {
        audioSource.PlayOneShot(enemyDeathAudio);
    }

    public void PlayerShootSound()
    {
        audioSource.PlayOneShot(playerShootAudio);
    }

    public void EnemyShootSound()
    {
        audioSource.PlayOneShot(enemyShootAudio);
    }

    public void ItemCollectedSound()
    {
        audioSource.PlayOneShot(itemCollectedAudio);
    }

    public void CerrarPuertaSound()
    {
        audioSource.PlayOneShot(cerrarPuerta);
    }

    public void AbrirPuertaSound()
    {
        audioSource.PlayOneShot(abrirPuerta);
    }
}

