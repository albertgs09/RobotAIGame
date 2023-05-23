using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
   [SerializeField] private GameObject sphereRobot;
    private Transform aiPos;
   
    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            CheckArea();
            if(aiPos != null)
                TakeOverSphere();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            //Debug.Log("attack");
          // gameObject.GetComponent<Animator>().SetTrigger("Attack");
        }
    }
    private void CheckArea()
    {
        var cols = Physics.OverlapSphere(transform.position, 11.8f);
        foreach (Collider c in cols)
        {
            if (c.gameObject.CompareTag("SphereAI"))
            {
                aiPos = c.transform;
            }
        }
    }

    private void TakeOverSphere()
    {
        GameObject newRobot = Instantiate(sphereRobot, aiPos.position, aiPos.rotation);
        Destroy(aiPos.gameObject);
        gameObject.SetActive(false);

    }
}
