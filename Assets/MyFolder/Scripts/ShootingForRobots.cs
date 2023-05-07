using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingForRobots : MonoBehaviour
{
    [SerializeField]private float min, max;
    [SerializeField]private float minShot, maxShot;
    [SerializeField] private GameObject projectiles;
    [SerializeField] private Transform[] barrels;
    private float timeBetweenShot;
    private float restTime, origRestTime;
    private float currentTime = 3, origCurrentTime;
    private bool startTime, startRestTime;
    private float shotTime;
    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShot = Random.Range(minShot, maxShot);
        restTime = Random.Range(min, max);
        origRestTime = restTime;
        currentTime = Random.Range(min, max);
        origCurrentTime = currentTime;
        startTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime) currentTime -= Time.deltaTime;

        if (currentTime > 0 ) Fire();
        else
        {
            startTime = false;
            startRestTime = true;
        }

        if(startRestTime) restTime -= Time.deltaTime;
        if(restTime <= 0)
        {
            startTime = true;
            startRestTime=false;
            currentTime = origCurrentTime;
            restTime = origRestTime;
        }
    }

    void Fire()
    {
        shotTime += Time.deltaTime;

        if(shotTime > timeBetweenShot)
        {
            foreach(Transform barrel in barrels)
            {
                Instantiate(projectiles, barrel.position, barrel.rotation);
            }
            shotTime = 0;
        }
    }
}
