using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausarJuego : MonoBehaviour
{

    public MenuPausa menuPausa;
    public Canvas canvasPausa;

    private void Start()
    {
        menuPausa = GameObject.Find("CanvasPausa").GetComponent<MenuPausa>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //menuPausa.Pausa();
            canvasPausa.gameObject.SetActive(true);
        }
    }

}
