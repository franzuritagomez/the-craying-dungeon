using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    public void NuevaPartida()
    {
        SceneManager.LoadScene("Juego");
        Time.timeScale = 1f;
    }

    public void ModoInfinito()
    {
        SceneManager.LoadScene("JuegoInfinito");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
