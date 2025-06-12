using System;
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

    private String balasPrefsName = "BalasInv";
    private String cargadorPrefsName = "CarcagorInv";
    private String escenaPrefsName = "nombreEscena";

    private static string escenaAnt = "";
    private bool escenaDiferente = true;

    void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Nivel0" || currentScene.name == "Muestra")
        {
            municion = maxMunicion;
            cargador = 1;
        }
        else
        {
            LoadData();
        }

        if (currentScene.name != escenaAnt)
        {
            escenaDiferente = true;
            escenaAnt = currentScene.name;
        }
        else
        {
            escenaDiferente = false;
        }

        
        
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
        else if ((Input.GetKeyDown(KeyCode.R) && cargador == 0 && PausaJuego.juegoPausa == false))
        {
            controAU.sinMunicion.Play();
        }

        if (Input.GetButtonDown("Fire1") && municion > 0 && PausaJuego.juegoPausa == false)
        {
            Instantiate(proyectil, this.transform.position, this.transform.rotation);
            municion--;
            textMostrarBalas.text = "Municion: " + municion;
            controAU.disparo.Play();

        }
        else if (Input.GetButtonDown("Fire1") && municion == 0 && PausaJuego.juegoPausa == false)
        {
            controAU.sinMunicion.Play();
        }
    }

    private void OnDestroy()
    {
        if (escenaDiferente == true)
        {
            SaveData();
        }
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt(balasPrefsName, municion);
        PlayerPrefs.SetInt(cargadorPrefsName, cargador);
        PlayerPrefs.SetString(escenaPrefsName, escenaAnt);
    }

    private void LoadData()
    {
        municion = PlayerPrefs.GetInt(balasPrefsName);
        cargador = PlayerPrefs.GetInt(cargadorPrefsName);
        escenaAnt = PlayerPrefs.GetString(escenaPrefsName);
    }
}
