using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarJugador : MonoBehaviour
{
    private MoveZomb enemigo;


    void Start()
    {
        enemigo = GetComponentInParent<MoveZomb>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemigo.perseguir = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemigo.perseguir = false;
        }
    }
}
