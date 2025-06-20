using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Libros : MonoBehaviour
{

    public static int contadorLibros = 0;
    private BoxCollider triggerLibros;
    public AudioSource agarrar;

    void Start()
    {
        contadorLibros = 0;
        triggerLibros = this.GetComponent<BoxCollider>();
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agarrar.Play();
            contadorLibros++;
            triggerLibros.enabled = false;
            Destroy(this.gameObject, 0.3f);
        }
    }
}
