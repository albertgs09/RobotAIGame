using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotFriend : MonoBehaviour
{
    private GameObject player,target;
    [SerializeField] private GameObject lazer;
    private NavMeshAgent agent;
    [SerializeField]private Transform eye2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        agent.SetDestination(player.transform.position);
        Fire();
        if(target != null)
        {
            Vector3 newDir = new Vector3(target.transform.position.x, target.transform.position.y + 1, target.transform.position.z);
            transform.LookAt(newDir);
        }
    }

    private void Fire()
    {
        if(Input.GetButtonDown("Fire1")) Instantiate(lazer, eye2.position, eye2.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemies"))
        {
            target = other.gameObject;
            Debug.Log(target.name);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemies"))
        {
            target = null;
            Debug.Log("No target");
            Debug.Log(target);
        }
    }
}
