using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Transform target;
    [Range(0f, 20f)]
    [SerializeField] private float speed;

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime) ;
        Destroy(gameObject, 3f);
    }
}
