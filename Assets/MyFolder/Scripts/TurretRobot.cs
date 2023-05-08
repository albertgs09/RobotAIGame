using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRobot : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField]private float speed;
    [SerializeField]private int yPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("PlayerBody");     
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(UpdatePostion());
    }

    Vector3 UpdatePostion()
    {
        Vector3 updatedTarget = new Vector3(player.transform.position.x, player.transform.position.y + yPos, player.transform.position.z);
        return updatedTarget;
    }
}
