using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMov : MonoBehaviour
{
    public float velocidadMovimiento;
    public GameObject[] puntosDestino;
    private int indice = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, puntosDestino[indice].transform.position) <= 0.5f)
        {
            indice++;
            if (indice >= puntosDestino.Length)
            {
                indice = 0;
            }
        }

        this.transform.position = Vector3.MoveTowards(this.transform.position,
            puntosDestino[indice].transform.position, velocidadMovimiento * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }

    }
}
