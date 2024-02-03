using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausarMusica : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BGMusic.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }
}
