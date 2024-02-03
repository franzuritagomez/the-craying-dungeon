using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartHealth : MonoBehaviour
{

    public Sprite spr_full, spr_half, spr_empty;
    Image heartImage;

    // Start is called before the first frame update
    void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    public void SetHeartImage(HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.Empty:
                heartImage.sprite = spr_empty;
                break;
            case HeartStatus.Half:
                heartImage.sprite = spr_half;
                break;
            case HeartStatus.Full:
                heartImage.sprite = spr_full;
                break;
        }
    }
}

public enum HeartStatus
{
    Empty = 0,
    Half = 1,
    Full = 2
}
