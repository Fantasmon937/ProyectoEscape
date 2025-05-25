using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aarrena : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JugadorMov.multiplicadorVel /= 3;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JugadorMov.multiplicadorVel = 1;
        }
    }
}
