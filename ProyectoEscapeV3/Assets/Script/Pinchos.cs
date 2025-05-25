using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    private bool enPinchos = false;
    private VidaJugador jugador;
    private float contadorTiempo = 0;
    private float tiempoEntreGolpe = 0.3f;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<VidaJugador>();
    }

    void Update()
    {
        if (enPinchos)
        {
            contadorTiempo += Time.deltaTime;

            if (contadorTiempo >= tiempoEntreGolpe)
            {
                jugador.perderVida(2);
                contadorTiempo = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<VidaJugador>().perderVida(6);
            jugador.damage();
            enPinchos = true;
            contadorTiempo = 0;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugador.noDamage();
            enPinchos = false;
        }
    }
}
