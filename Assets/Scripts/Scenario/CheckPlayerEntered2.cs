using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerEntered2 : MonoBehaviour
{
    [Header("Referencias Puerta 1")]
    public GameObject go_Door;
    [SerializeField] private Animator anim;
    [SerializeField] private BoxCollider boxCollider;

    [Header("Referencias Puerta 2")]
    public GameObject go_Door2;
    [SerializeField] private Animator anim2;
    [SerializeField] private BoxCollider boxCollider2;

    public static event Action OnClosedDoor;

    // Start is called before the first frame update
    void Start()
    {
        if (go_Door != null)
        {
            anim = go_Door.GetComponent<Animator>();
            boxCollider = go_Door.GetComponent<BoxCollider>();
        }

        if (go_Door2 != null)
        {
            anim2 = go_Door2.GetComponent<Animator>();
            boxCollider2 = go_Door2.GetComponent<BoxCollider>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Player"))
        {
            Debug.Log("Player");
            // Puerta 1
            if (go_Door != null)
            {
                anim.SetBool("b_isOpened", false);
                OnClosedDoor?.Invoke();
            }

            // Puerta 2
            if (go_Door2 != null)
            {
                anim2.SetBool("b_isOpened", false);
                OnClosedDoor?.Invoke();
            }
        }
        if (other.tag.Equals("Enemy"))
        {
            if (go_Door != null)
            {
                other.gameObject.transform.SetParent(go_Door.transform.parent.parent.parent);
            } else {
                other.gameObject.transform.SetParent(go_Door2.transform.parent.parent.parent);
            }

            if (go_Door2 != null)
            {
                other.gameObject.transform.SetParent(go_Door2.transform.parent.parent.parent);
            }
            else
            {
                other.gameObject.transform.SetParent(go_Door.transform.parent.parent.parent);
            }
        }
    }
}
