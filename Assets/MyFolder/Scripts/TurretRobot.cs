using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRobot : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField]private float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("PlayerBody");     
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
    }
}
