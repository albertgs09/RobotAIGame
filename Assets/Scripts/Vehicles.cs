using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Vehicles : MonoBehaviour
{
    [Range(0f, 50f)]
    public float speed = 12f;
    public float gravity;
    private Vector3 dir;
    private CharacterController cc;
    public GameObject vehicleModel, player;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();   
    }
   
    // Update is called once per frame
    void Update()
    {
        var horiz = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");
        //free movement
        dir = transform.right * horiz + transform.forward * vert ;
        //forward and back
        //dir =  transform.forward * vert ;
        //pulls down object
        dir.y -= gravity * 15 * Time.deltaTime;
        //moves object
        cc.Move(dir * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(vehicleModel, transform.position, transform.rotation) ;
            Instantiate(player, new Vector3(transform.position.x - 3, transform.position.y,transform.position.z), transform.rotation) ;
            Destroy(gameObject);

        }
    }
}
