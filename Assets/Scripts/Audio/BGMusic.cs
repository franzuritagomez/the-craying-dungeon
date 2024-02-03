using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    private static BGMusic instance;

    public static BGMusic Instance
    {
        get => instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;

        }
        DontDestroyOnLoad(this.gameObject);
    }
}
