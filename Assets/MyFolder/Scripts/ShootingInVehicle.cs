using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingInVehicle : MonoBehaviour
{
    [SerializeField]private GameObject projectiles;
    [SerializeField]private Transform[] barrels;
    private float timeBetweenShot;
    private CheckTargets checkTargets;
    private Transform target;
    private void Start()
    {
        checkTargets = GetComponent<CheckTargets>();
    }
    private void Update()
    {
        timeBetweenShot += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timeBetweenShot > .5f)
        {
            Fire();
            timeBetweenShot = 0;
        }
    }

    private void Fire()
    {
        if (checkTargets != null)
            target = checkTargets.CheckClosestTarget();
        //Instantiates a projectile to each barrel 
        foreach (Transform barrel in barrels)
        {
            GameObject rocket = Instantiate(projectiles, barrel.position, barrel.rotation);

            //if a rocket, then adds target to rocket script
            if (projectiles.name == "Rockets")
                if (target != null) rocket.GetComponent<Rocket>().target = target;
        }
    }
}
