using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceRobotMovement : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    private GameObject target;
    private ShootingForRobots shooting;
    private float attackTime, deathTime;
    private bool near, dead;

    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        shooting = GetComponent<ShootingForRobots>();
        target = GameObject.Find("Player");
    }

    private void Update()
    {
        if(!dead) Move();
        else
        {
            deathTime += Time.deltaTime;
            agent.isStopped = true;
            GameObject effects = GameObject.Find("Effects");
            if(deathTime >= 3)
            {
                effects.GetComponent<Effects>().ChooseEffect(0, transform);
                Destroy(gameObject);
            }
        }
    }

    private void Move()
    {
        //gets distance between to objects
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance >= agent.stoppingDistance + 3) near = false;
        else near = true;

        //sets destination and animation
        if (distance >= agent.stoppingDistance + 3 && !agent.isStopped)
        {
            agent.SetDestination(target.transform.position);
            anim.SetBool("IsWalking", true);
        }
        else
        {
            //sets up attack function
            agent.isStopped = true;
            anim.SetBool("IsWalking", false);
            transform.LookAt(target.transform);
            Attack();
        }
    }

   private void Attack()
    {
        if (near)
        {
            attackTime += Time.deltaTime;

            if (attackTime > 1)
            {
                anim.SetTrigger("Attack");
                attackTime = 0;
            }
        }
    }

    private void MoveAI()
    {
        //Tied to attack animation
        agent.isStopped = !agent.isStopped;
        shooting.enabled = !shooting.enabled;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            dead = true;
            anim.SetTrigger("Dead");
        }
    }
}
