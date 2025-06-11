using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorItem : MonoBehaviour
{
    public TextMeshProUGUI textCantidadCer;
    public static int cantidadCer = 1;
    public TextMeshProUGUI textCantidadVend;
    public static int cantidadVend = 1;
    public TextMeshProUGUI textCantidadBoti;
    public static int cantidadBoti = 1;

    private VidaJugador jugador;
    public AudioSource agarrar;

    private String itemBotiPrefsName = "ItemBoti";
    private String itemCerPrefsName = "ItemCer";
    private String itemVendPrefsName = "ItemVend";



    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Nivel0" || currentScene.name == "Muestra" )
        {
            cantidadBoti = 1;
            cantidadCer = 1;
            cantidadVend = 1;
        }
        else
        {
            LoadData();
        }
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<VidaJugador>();
        textCantidadCer.text = cantidadCer + "";
        textCantidadVend.text = cantidadVend + "";
        textCantidadBoti.text = cantidadBoti + "";
    }

    // Update is called once per frame
    void Update()
    {
        textCantidadCer.text = cantidadCer + "";
        textCantidadVend.text = cantidadVend + "";
        textCantidadBoti.text = cantidadBoti + "";

        if (PausaJuego.juegoPausa == false)
        {
            if (cantidadCer > 0 && Input.GetKeyDown(KeyCode.Alpha1))
            {
                usarItemCer();
                agarrar.Play();
            }
            if (cantidadVend > 0 && Input.GetKeyDown(KeyCode.Alpha2))
            {
                usarItemVen();
                agarrar.Play();
            }
            if (cantidadBoti > 0 && Input.GetKeyDown(KeyCode.Alpha3))
            {
                usarItemBoti();
                agarrar.Play();
            }
        }

        
    }


    public void usarItemCer()
    {
        cantidadCer--;
        textCantidadCer.text = cantidadCer + "";
        JugadorMov.multiplicadorVel = 3;
        Invoke(nameof(restablecerVelocidad), 3);
    }
    private void restablecerVelocidad()
    {
        JugadorMov.multiplicadorVel = 1;
    }

    public void usarItemVen()
    {
        cantidadVend--;
        textCantidadVend.text = cantidadVend + "";
        jugador.ganarVida(10);
        jugador.curar();
        Invoke("colorBlan", 0.3f);
        //JugadorMov.multiSaltoFu = 1.5f;
        //Invoke(nameof(restablecerSalto), 3);
    }

    public void usarItemBoti()
    {
        textCantidadBoti.text = cantidadBoti + "";
        cantidadBoti--;
        jugador.ganarVida(20);
        jugador.curar();
        Invoke("colorBlan", 0.3f);
    }

    private void colorBlan()
    {
        jugador.noDamage();
    }

    private void OnDestroy()
    {
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt(itemVendPrefsName, cantidadVend);
        PlayerPrefs.SetInt(itemCerPrefsName, cantidadCer);
        PlayerPrefs.SetInt(itemBotiPrefsName, cantidadBoti);
    }

    private void LoadData()
    {
        cantidadBoti = PlayerPrefs.GetInt(itemBotiPrefsName, 0);
        cantidadVend = PlayerPrefs.GetInt(itemVendPrefsName, 0);
        cantidadCer = PlayerPrefs.GetInt(itemCerPrefsName, 0);
    }


}
