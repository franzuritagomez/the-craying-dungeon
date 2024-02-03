using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShootingBehaviour : MonoBehaviour
{
    public static event Action OnPlayerShoot;

    [Header("Referencias")]
    public GameObject go_bullet;
    public PlayerMovement character;

    [Header("Stats")]
    public float shootForce, upwardForce;

    //Gun stats
    public float timeBetweenShooting, timeBetweenShots;
    public int  bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //bools
    bool shooting, readyToShoot;
    public bool reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    GameObject currentBullet;

    //bug fixing :D
    public bool allowInvoke = true;

    private void Awake()
    {
        //make sure magazine is full
        readyToShoot = true;
        allowButtonHold = true;
    }

    private void Update()
    {
        MyInput();
    }
    private void MyInput()
    {
        //Check if allowed to hold down button and take corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Shooting
        if (readyToShoot && shooting)
        {
            Shoot();
        }
    }

    private void Shoot()
    {

        readyToShoot = false;

        //Find the exact hit position using a raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.51f, 0f)); //Just a ray through the middle of your current view
        RaycastHit hit;

        //check if ray hits something
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75); //Just a point far away from the player
        }

        //Calculate direction from attackPoint to targetPoint
        Vector3 direction = targetPoint - attackPoint.position;

        OnPlayerShoot?.Invoke();
        currentBullet = Instantiate(go_bullet, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet 
        Destroy(currentBullet, 3f);
        currentBullet.transform.forward = direction.normalized;

        //Disparo pistola normal
        //shootForce; 
        upwardForce = 0f;
        currentBullet.GetComponent<Rigidbody>().useGravity = false;
        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce * character.f_speed * 1.5f, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot++;


        //Invoke resetShot function (if not already invoked), with your timeBetweenShooting
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        //if more than one bulletsPerTap make sure to repeat shoot function
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        //Allow shooting and invoking again
        readyToShoot = true;
        allowInvoke = true;
    }
}
