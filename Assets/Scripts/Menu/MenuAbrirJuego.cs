using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAbrirJuego : MonoBehaviour
{

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }

}
