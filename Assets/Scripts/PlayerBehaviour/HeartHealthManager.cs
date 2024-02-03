using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHealthManager : MonoBehaviour
{

    public GameObject go_heartPrefab;
    public PlayerHealth playerHealth;

    List<HeartHealth> healthList = new List<HeartHealth>();

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDamaged += DrawHearts;
        PlayerHealth.OnPlayerHealth += DrawHearts;
        PlayerHealth.OnPlayerMaxHealth += DrawHearts;
        PlayerHealth.OnPlayerDeath += DrawHearts;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDamaged -= DrawHearts;
        PlayerHealth.OnPlayerHealth -= DrawHearts;
        PlayerHealth.OnPlayerMaxHealth -= DrawHearts;
        PlayerHealth.OnPlayerDeath -= DrawHearts;
    }

    private void Start()
    {
        DrawHearts();
    }

    public void DrawHearts()
    {
        ClearHearts();

        //Determinar cuantos corazones hay en total basandonos en la vida máxima
        float f_maxHealthRemainder = playerHealth.f_maxHealth % 2;
        int i_heartsToMake = (int)((playerHealth.f_maxHealth / 2) + f_maxHealthRemainder);
        for (int i = 0; i < i_heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0; i < healthList.Count; i++)
        {
            int i_heartStatusRemainder = (int)Mathf.Clamp(playerHealth.f_health - (i * 2), 0, 2);
            healthList[i].SetHeartImage((HeartStatus)i_heartStatusRemainder);
        }
    }

    public void CreateEmptyHeart()
    {
        GameObject go_newHeart = Instantiate(go_heartPrefab);
        go_newHeart.transform.SetParent(transform);

        HeartHealth heartComponent = go_newHeart.GetComponent<HeartHealth>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        healthList.Add(heartComponent);
    }



    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        healthList = new List<HeartHealth>();
    }
}
