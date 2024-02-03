using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyInRoom : MonoBehaviour
{
    [Header("Referencias Puerta")]
    public GameObject go_Door;
    [SerializeField] private Animator anim;
    [SerializeField] private BoxCollider boxCollider;

    [Header("Referencias Enemigos")]
    public GameObject[] allChildren;
    public int i_allChildrenLenght;
    public List<GameObject> listaEnemy = new List<GameObject>();

    [Header("Referencias Trofeo")]
    public RoomTemplates roomTemplates;
    public GameObject go_Trofeo;
    public bool b_Instanciado = false;

    public static event Action OnOpenDoor;
    bool b_Reproducido = false;

    void Start()
    {
        anim = go_Door.GetComponent<Animator>();
        boxCollider = go_Door.GetComponent<BoxCollider>();
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
                else
                {
                    boxCollider.enabled = true;
                    anim.SetBool("b_isOpened", true);
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
