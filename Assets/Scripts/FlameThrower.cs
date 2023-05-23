using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    [SerializeField] private GameObject flamethrower;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            flamethrower.SetActive(true);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            flamethrower.SetActive(false);
        }
    }
}
