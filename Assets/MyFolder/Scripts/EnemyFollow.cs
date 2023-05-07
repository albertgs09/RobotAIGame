using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agent;
    private Animator anim;
    public string walk;
    private bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim != null) Animations();
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if(distance > agent.stoppingDistance)
        {
            agent.SetDestination(target.transform.position);
            isWalking = true;
        }
        else isWalking = false;
    }

    void Animations()
    {
        anim.SetBool(walk, isWalking);
    }
}
