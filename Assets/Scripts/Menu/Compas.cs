using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compas : MonoBehaviour
{

    public RectTransform compasTransform;
    public RectTransform objetivoCompas;
    public RectTransform objetivoTienda;
    public RectTransform objetivoItem;

    public Transform camaraTransform;
    public Transform bossTransform;
    public Transform tiendaTransform;
    public Transform itemTransform;

    private RoomTemplates roomTemplates;
    private Teleport go_PortalTienda;
    private Teleport go_PortalItem;

    private void Start()
    {
        Invoke("CogerBossObjetivo", 1.2f);
        Invoke("CogerPortalTienda",2f);
        Invoke("CogerPortalItem", 2);
    }

    // Update is called once per frame
    void Update()
    {
        SetPosicionBossCompas(objetivoCompas, bossTransform.position);
        SetPosicionTiendaCompas(objetivoTienda, tiendaTransform.position);
        SetPosicionItemCompas(objetivoItem, itemTransform.position);
    }

    private void SetPosicionBossCompas(RectTransform marcador, Vector3 v3_posicionGlobal)
    {
        Vector3 v3_direccionObjetivo = v3_posicionGlobal - camaraTransform.position;
        float f_angulo = Vector2.SignedAngle(new Vector2(v3_direccionObjetivo.x, v3_direccionObjetivo.z),
            new Vector2(camaraTransform.transform.forward.x, camaraTransform.transform.forward.z));
        float f_compasX = Mathf.Clamp(2 * f_angulo / Camera.main.fieldOfView, -1, 1);
        marcador.anchoredPosition = new Vector2(compasTransform.rect.width / 2 * f_compasX, 0);
    }

    private void SetPosicionTiendaCompas(RectTransform marcador, Vector3 v3_posicionGlobal)
    {
        Vector3 v3_direccionObjetivo = v3_posicionGlobal - camaraTransform.position;
        float f_angulo = Vector2.SignedAngle(new Vector2(v3_direccionObjetivo.x, v3_direccionObjetivo.z),
            new Vector2(camaraTransform.transform.forward.x, camaraTransform.transform.forward.z));
        float f_compasX = Mathf.Clamp(2 * f_angulo / Camera.main.fieldOfView, -1, 1);
        marcador.anchoredPosition = new Vector2(compasTransform.rect.width / 2 * f_compasX, 0);
    }

    private void SetPosicionItemCompas(RectTransform marcador, Vector3 v3_posicionGlobal)
    {
        Vector3 v3_direccionObjetivo = v3_posicionGlobal - camaraTransform.position;
        float f_angulo = Vector2.SignedAngle(new Vector2(v3_direccionObjetivo.x, v3_direccionObjetivo.z),
            new Vector2(camaraTransform.transform.forward.x, camaraTransform.transform.forward.z));
        float f_compasX = Mathf.Clamp(2 * f_angulo / Camera.main.fieldOfView, -1, 1);
        marcador.anchoredPosition = new Vector2(compasTransform.rect.width / 2 * f_compasX, 0);
    }

    private void CogerBossObjetivo()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        bossTransform = roomTemplates.t_salaBoss.transform;
    }

    private void CogerPortalTienda()
    {
        go_PortalTienda = GameObject.FindGameObjectWithTag("PortalTienda").GetComponent<Teleport>();
        tiendaTransform = go_PortalTienda.transform;
    }

    private void CogerPortalItem()
    {
        go_PortalItem = GameObject.FindGameObjectWithTag("PortalSalaItem").GetComponent<Teleport>();
        itemTransform = go_PortalItem.transform;
    }
}
