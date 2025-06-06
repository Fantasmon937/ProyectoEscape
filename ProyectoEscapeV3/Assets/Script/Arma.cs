using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject proyectil;
    public static int municion = 3;
    public static int cargador = 0;
    public TextMeshProUGUI textMostrarBalas;
    public TextMeshProUGUI textMostrarCargador;

    public ControlarAudio controAU;

    void Start()
    {
        municion = 3;
        cargador = 0;
        textMostrarBalas.text = "Municion: " + municion;
        textMostrarCargador.text = "Cargadores: " + cargador;
    }

    void Update()
    {
        textMostrarCargador.text = "Cargadores: " + cargador;

        if (Input.GetKeyDown(KeyCode.R) && cargador>0 && PausaJuego.juegoPausa == false)
        {
            municion = municion+ 6;
            cargador--;
            textMostrarBalas.text = "Municion: " + municion;
            controAU.recarga.Play();
            

        }

        if (Input.GetButtonDown("Fire1") && municion > 0 && PausaJuego.juegoPausa == false)
        {
            Instantiate(proyectil, this.transform.position, this.transform.rotation);
            municion--;
            textMostrarBalas.text = "Municion: " + municion;
            controAU.disparo.Play();

        }
    }
}
