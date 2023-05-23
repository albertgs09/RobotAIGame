using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLazer : MonoBehaviour
{
    [SerializeField] private GameObject aimfriend, aiFriend, back;
    [SerializeField] private GameObject lazer;
    [SerializeField] private Transform eye;
    [SerializeField] private Animator aimAnim;
    [SerializeField] private bool readyToFire;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        FiringInputs();
    }

    private void FiringInputs()
    {
       // if (Input.GetButton("Aim")) Aim();
        //if (Input.GetButtonUp("Aim")) NotAiming();
        if (Input.GetButtonDown("Fire1") && readyToFire) FireShoulder();
    }

    private void Aim()
    {
        readyToFire = true;
        aimfriend.SetActive(true);
        aiFriend.SetActive(false);
    }

    private void NotAiming()
    {
        aimAnim.SetTrigger("Back");
        readyToFire = false;
        aiFriend.SetActive(true);
        aiFriend.transform.position =back.transform.position;
    }

   

    private void FireShoulder()
    {
        Instantiate(lazer, eye.position, eye.rotation);
    }
   
}
