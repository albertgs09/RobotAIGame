using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] private float speed;
    private GameObject fx;
    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemies"))
        {
            fx = GameObject.Find("Effects");
            fx.GetComponent<Effects>().ChooseEffect(0, transform);
            Destroy(gameObject);
        }
    }
}
