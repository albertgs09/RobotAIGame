using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleInteractions : MonoBehaviour
{
    public GameObject vehicle;
    private GameObject player;
    private bool canPress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canPress && Input.GetKeyDown(KeyCode.E)){
            Instantiate(vehicle, transform.position, transform.rotation);
            player.SetActive(false);
            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            canPress = true;
            Debug.Log("Press E to enter");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canPress = false;
            Debug.Log("no ride");
        }
    }
}
