using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    public static bool b_JuegoPausado = false;

    public GameObject menuPausa;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (b_JuegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Reanudar()
    {
        menuPausa.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        b_JuegoPausado = false;
    }

    public void Pausar()
    {
        menuPausa.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
        b_JuegoPausado = true;
    }

    public void SalirMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuAbrirJuego");
    }
}
