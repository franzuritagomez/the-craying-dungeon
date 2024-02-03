using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventario : MonoBehaviour
{

    public int i_cantidadCoin = 0;
    public int i_cantidadKey = 0;
    public int i_cantidadBomb = 0;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] TextMeshProUGUI keyText;
    [SerializeField] TextMeshProUGUI bombText; 
    public GameObject go_Winner;
    public AudioSource ad;

    private void Start()
    {
        ad = GameObject.Find("Canvas").GetComponent<AudioSource>();
    }

    private void Update()
    {
        coinsText.text = $"Coins: {i_cantidadCoin}";
        keyText.text = $"Keys: {i_cantidadKey}";
        bombText.text = $"Bombs: {i_cantidadBomb}";
    }

    public int getBombas()
    {
        return i_cantidadBomb;
    }
    public int getLLaves()
    {
        return i_cantidadKey;
    }
    public int getCoins()
    {
        return i_cantidadCoin;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Trofeo"))
        {
            go_Winner.SetActive(true);
            ad.Pause();
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
        }
    }
}
