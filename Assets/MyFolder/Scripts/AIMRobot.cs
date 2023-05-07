using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMRobot : MonoBehaviour
{
    public Transform aimPoint;
    private Vector3 hitPosition;
    private bool hitSomething;
    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            hitSomething = true;
            hitPosition = hit.point;
        }
        else hitSomething = false;

        if (hitSomething) transform.LookAt(hitPosition);
        else transform.LookAt(aimPoint);

    }
}
