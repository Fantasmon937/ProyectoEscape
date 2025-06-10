using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arma : MonoBehaviour
{
    public GameObject proyectil;
    public static int municion = 6;
    public static int cargador = 1;
    private int maxMunicion = 6;
    private int maxCargador;
    public TextMeshProUGUI textMostrarBalas;
    public TextMeshProUGUI textMostrarCargador;

    public ControlarAudio controAU;

    void Start()
    {
        municion = maxMunicion;
        cargador = 1;
        textMostrarBalas.text = "Municion: " + municion;
        textMostrarCargador.text = "Cargadores: " + cargador;

    }

    void Update()
    {
        textMostrarCargador.text = "Cargadores: " + cargador;

        if (Input.GetKeyDown(KeyCode.R) && cargador>0 && PausaJuego.juegoPausa == false)
        {
            municion = maxMunicion;
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

        }else if (Input.GetButtonDown("Fire1") && municion == 0 && PausaJuego.juegoPausa == false)
        {
            controAU.sinMunicion.Play();
        }
    }
}
