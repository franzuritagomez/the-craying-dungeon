using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoldenRoom_Shop_Spawner : MonoBehaviour
{
    public List<GameObject> l_go_salas = new List<GameObject>();
    public GameObject go_TeleportItem;
    public GameObject go_TeleportShop;


    RoomTemplates salas;


    void Start()
    {
        salas = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        l_go_salas = salas.rooms;
        Invoke("GenerationGoldenRoom", 1);
    }

    private void GenerationGoldenRoom()
    {
        int i_listLenght = l_go_salas.Count;
        GameObject go_penultimaSala = l_go_salas.ElementAt(i_listLenght - 2);

        if (go_penultimaSala.gameObject.name.Equals("_01_Bottom(Clone)"))
        {
            //Portal Sala Dorada
            go_TeleportItem.transform.position = new Vector3(0 + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, 8.5f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportItem);

            //Portal Tienda
            go_TeleportShop.transform.position = new Vector3(-8.5f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, 0f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportShop);
        }
        else if (go_penultimaSala.gameObject.name.Equals("_01_Left(Clone)"))
        {
            //Portal Sala Dorada
            go_TeleportItem.transform.position = new Vector3(8.5f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, 0 + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportItem);

            //Portal Tienda
            go_TeleportShop.transform.position = new Vector3(0f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, 8.5f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportShop);
        }
        else if (go_penultimaSala.gameObject.name.Equals("_01_LeftBottom(Clone)"))
        {
            //Portal Sala Dorada
            go_TeleportItem.transform.position = new Vector3(0f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, 8.5f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportItem);

            //Portal Tienda
            go_TeleportShop.transform.position = new Vector3(8.5f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, 0f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportShop);
        }
        else if (go_penultimaSala.gameObject.name.Equals("_01_LeftRight(Clone)"))
        {
            //Portal Sala Dorada
            go_TeleportItem.transform.position = new Vector3(0f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, 8.5f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportItem);

            //Portal Tienda
            go_TeleportShop.transform.position = new Vector3(0f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, -8.5f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportShop);
        }
        else if (go_penultimaSala.gameObject.name.Equals("_01_Right(Clone)"))
        {
            //Portal Sala Dorada
            go_TeleportItem.transform.position = new Vector3(-8.5f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, 0f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportItem);

            //Portal Tienda
            go_TeleportShop.transform.position = new Vector3(0f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, -8.5f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportShop);
        }
        else if (go_penultimaSala.gameObject.name.Equals("_01_RightBottom(Clone)"))
        {
            //Portal Sala Dorada
            go_TeleportItem.transform.position = new Vector3(0f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, 8.5f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportItem);

            //Portal Tienda
            go_TeleportShop.transform.position = new Vector3(-8.5f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, 0f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportShop);
        }
        else if (go_penultimaSala.gameObject.name.Equals("_01_Top(Clone)"))
        {
            //Portal Sala Dorada
            go_TeleportItem.transform.position = new Vector3(0f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, -8.5f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportItem);

            //Portal Tienda
            go_TeleportShop.transform.position = new Vector3(8.5f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, 0f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportShop);
        }
        else if (go_penultimaSala.gameObject.name.Equals("_01_TopBottom(Clone)"))
        {
            //Portal Sala Dorada
            go_TeleportItem.transform.position = new Vector3(8.5f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, 0f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportItem);

            //Portal Tienda
            go_TeleportShop.transform.position = new Vector3(-8.5f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, 0f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportShop);
        }
        else if (go_penultimaSala.gameObject.name.Equals("_01_TopLeft(Clone)"))
        {
            //Portal Sala Dorada
            go_TeleportItem.transform.position = new Vector3(8.5f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, 0f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportItem);

            //Portal Tienda
            go_TeleportShop.transform.position = new Vector3(0f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, -8.5f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportShop);
        }
        else if (go_penultimaSala.gameObject.name.Equals("_01_TopRight(Clone)"))
        {
            //Portal Sala Dorada
            go_TeleportItem.transform.position = new Vector3(0f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, -8.5f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportItem);

            //Portal Tienda
            go_TeleportShop.transform.position = new Vector3(-8.5f + go_penultimaSala.transform.position.x,
                2f + go_penultimaSala.transform.position.y, 0f + go_penultimaSala.transform.position.z);
            Instantiate(go_TeleportShop);
        }
    }
}
