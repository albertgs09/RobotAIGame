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

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //if object has animations
        if (anim != null) Animations();
        //Make object go towards player
        if(agent.remainingDistance <  agent.stoppingDistance)
        {
            agent.SetDestination(target.transform.position);
            isWalking = true;
        }
        else isWalking = false;
    }

    private void Animations()
    {
        anim.SetBool(walk, isWalking);
    }
}
