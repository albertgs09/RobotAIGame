using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SphereOverride : MonoBehaviour
{
    [Range(0f, 50f)]
    [SerializeField]private float speed = 2f;
    [SerializeField]private float gravity = 9.81f;
    private Vector3 dir;
    private CharacterController cc;
    private Animator anim;
    [SerializeField]private GameObject sphereAI;
    public GameObject player;
    private bool canRoll, readyToBegin, noMoving, startRolling;
    private ShootingInVehicle firing;
    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();    
        firing = GetComponent<ShootingInVehicle>();
        firing.enabled = false;
    }
   
    public void CanBooleans(int num)
    {
        switch (num)
        {
            case 0:
                readyToBegin = true;
                break;
            case 1:
                canRoll = false;
                break;
            case 2:
                noMoving = true;
                break;
            case 3: noMoving = false;
                break;
            case 4:
                startRolling = true;
                break;
            case 5:
                startRolling = false;
                break;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
        Move();
        Exit();
        Roll();
    }

    private void Move()
    {
        if (!canRoll && readyToBegin && !noMoving)
        {
            firing.enabled = true;
            anim.SetBool("Roll_Anim", false);
            var vert = Input.GetAxis("Vertical");
            //forward and back
            dir = transform.forward * vert;
            //pulls down object
            dir.y -= gravity * 15 * Time.deltaTime;
            //moves object
            cc.Move(dir * speed * Time.deltaTime);

            if (vert > 0 || vert < 0)
            {
                anim.SetBool("Walk_Anim", true);
                if (vert < 0) anim.SetFloat("Blend", 1);
                else if (vert > 0) anim.SetFloat("Blend", 0);
            }
            else anim.SetBool("Walk_Anim", false);     
        }
    }
    private void Roll()
    {
        if (Input.GetKey(KeyCode.R))
        {
            canRoll = true;   
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            canRoll=false;
        }

        if (canRoll && !noMoving )
        {
            firing.enabled=false;
            anim.SetBool("Roll_Anim", true);
            anim.SetBool("Walk_Anim", false);
            if (startRolling)
            {
                Vector3 rollDir = transform.forward;
                rollDir.y -= gravity * 15 * Time.deltaTime;
                cc.Move(rollDir * (speed + 25) * Time.deltaTime);
            }
           
        }
    }

    private void Exit()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Instantiate(sphereAI, transform.position, transform.rotation);
            player.SetActive(true);
            Destroy(gameObject);

        }
    }
}
