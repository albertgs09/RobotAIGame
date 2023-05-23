using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCam : MonoBehaviour
{
    [Range(0f, 150f)]
    public float mouseSensitivity = 100f;
    public Transform body;
    private float xRotation;
    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        body.Rotate(Vector3.up * mouseX);
    }
}
