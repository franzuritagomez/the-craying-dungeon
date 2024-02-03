using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerEntered : MonoBehaviour
{
    [Header("Referencias Puerta 1")]
    public GameObject go_Door;
    [SerializeField] private Animator anim;
    public static event Action OnClosedDoor;

    // Start is called before the first frame update
    void Start()
    {
        anim = go_Door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Player"))
        {
            anim.SetBool("b_isOpened", false);
            OnClosedDoor?.Invoke();
        }
        if (other.tag.Equals("Enemy"))
        {
            other.gameObject.transform.SetParent(go_Door.transform.parent.parent.parent);
        }
    }
}
