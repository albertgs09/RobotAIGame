using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField]private GameObject[] effects;
        
    public void ChooseEffect(int num, Transform target)
    {
        Debug.Log("Particle effect");
        GameObject effect = Instantiate(effects[num], target.position, target.rotation);
        Destroy(effect, 3f);
    }
}   
