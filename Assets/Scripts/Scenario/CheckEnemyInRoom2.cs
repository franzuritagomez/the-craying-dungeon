using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CheckEnemyInRoom2 : MonoBehaviour
{
    [Header("Referencias Puerta 1")]
    public GameObject go_Door;
    [SerializeField] private Animator anim;
    [SerializeField] private BoxCollider boxCollider;

    [Header("Referencias Puerta 2")]
    public GameObject go_Door2;
    [SerializeField] private Animator anim2;
    [SerializeField] private BoxCollider boxCollider2;

    [Header("Referencias Enemigos")]
    public GameObject[] allChildren;
    public List<GameObject> listaEnemy = new List<GameObject>();
    public int i_allChildrenLenght;

    [Header("Referencias Trofeo")]
    public RoomTemplates roomTemplates;
    public GameObject go_Trofeo;
    public bool b_Instanciado = false;

    public static event Action OnOpenDoor;
    bool b_Reproducido=false;

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

        Invoke("getAllChildrenLenght", 2f);

        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    private void Update()
    {
        allChildren = new GameObject[gameObject.transform.childCount];
        for (int i = 0; i < allChildren.Length; i++)
        {
            allChildren[i] = gameObject.transform.GetChild(i).gameObject;
            if (allChildren[i].tag.Equals("Enemy"))
            {
                if (listaEnemy.Count < 5)
                {
                    listaEnemy.Add(allChildren[i]);
                }
            }
            if (allChildren.Length <= i_allChildrenLenght - listaEnemy.Count)
            {
                if (roomTemplates.t_salaBoss.gameObject == gameObject)
                {
                    go_Trofeo.transform.position = new Vector3(gameObject.transform.position.x,
                        gameObject.transform.position.y + 1f, gameObject.transform.position.z);
                    if (!b_Instanciado)
                    {
                        Instantiate(go_Trofeo);
                        b_Instanciado = true;
                        boxCollider.enabled = false;
                        anim.SetBool("b_isOpened", false);
                    }
                }
                //Puerta 1
                 if (go_Door != null)
                {
                    anim.SetBool("b_isOpened", true);
                    boxCollider.enabled = true;
                    if (!b_Reproducido)
                    {
                        OnOpenDoor?.Invoke();
                        b_Reproducido = true;
                    }
                }

                //Puerta 2
                 if (go_Door2 != null)
                {
                    anim2.SetBool("b_isOpened", true);
                    boxCollider2.enabled = true;
                    if (!b_Reproducido)
                    {
                        OnOpenDoor?.Invoke();
                        b_Reproducido = true;
                    }
                }
            }
        }
    }

    private void getAllChildrenLenght()
    {
        allChildren = new GameObject[gameObject.transform.childCount];
        i_allChildrenLenght = allChildren.Length;
    }

}
