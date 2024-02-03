using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public Transform t_targetTienda;
    public Transform t_targetItem;
    public Transform t_targetDungeon;
    public GameObject go_player;
    Inventario inventario;

    private void Start()
    {
        go_player = GameObject.FindGameObjectWithTag("Player");
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
        t_targetTienda = GameObject.FindGameObjectWithTag("Tienda").GetComponent<Transform>();
        t_targetItem = GameObject.FindGameObjectWithTag("SalaItem").GetComponent<Transform>();
        t_targetDungeon = GameObject.FindGameObjectWithTag("Dungeon").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.LookAt(go_player.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (gameObject.tag.Equals("PortalTienda"))
            {
                if (inventario.i_cantidadKey >= 1)
                {
                    inventario.i_cantidadKey -= 1;
                    go_player.transform.position = t_targetTienda.transform.position;
                }
            }
            if (gameObject.tag.Equals("PortalSalaItem"))
            {
                if (inventario.i_cantidadKey >= 1)
                {
                    inventario.i_cantidadKey -= 1;
                    go_player.transform.position = t_targetItem.transform.position;
                }
            }
            if (gameObject.tag.Equals("PortalDungeon"))
            {
                Debug.Log("Trigger en PortalDungeon");
                go_player.transform.position = t_targetDungeon.transform.position;
            }
        }
    }


}
