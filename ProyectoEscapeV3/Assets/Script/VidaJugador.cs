using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    public static int vida = 80;
    public Slider barraVida;
    public TextMeshProUGUI textVida;
    public Material color;

    public ControlarAudio controAU;

    private String vidaPrefsName = "ItemVida";

    private string escenaAnt = "";
    private bool escenaDiferente = true;

    void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name != escenaAnt)
        {
            escenaDiferente = true;
            escenaAnt = currentScene.name;
        }
        else
        {
            escenaDiferente = false;
        }

        if (currentScene.name == "Nivel0" || currentScene.name == "Muestra")
        {
            vida = 80;
        }
        else
        {
            LoadData();
        }
        noDamage();
    }

    // Update is called once per frame
    void Update()
    {

        barraVida.value = vida;
        textVida.text = barraVida.value+"";
    }

    public void ganarVida(int incrementoVida)
    {
        if(vida < 100)
        {
            if (incrementoVida > 0)
            {
                vida += incrementoVida;
            }
            else
            {
                vida -= incrementoVida;
            }
        }
        
    }

    public void perderVida(int decrementoVida)
    {
        
        if (vida > 0)
        {
            
            if (decrementoVida > 0)
            {
                
                vida -= decrementoVida;
            }
            else
            {
                vida += decrementoVida;
            }
        }
        
    }

    public int consultarvida()
    {
        return vida;
    }

    public void damage()
    {
        controAU.golpe.Play();
        color.SetColor("_BaseColor", new Color(0.91f, 0.3f, 0.21f));
    }
    public void noDamage()
    {
        controAU.golpe.Stop();
        color.SetColor("_BaseColor", Color.white);
    }

    public void curar()
    {
        color.SetColor("_BaseColor", new Color(0.41f, 0.81f, 0.41f));
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
        PlayerPrefs.SetInt(vidaPrefsName, vida);
    }

    private void LoadData()
    {
        vida = PlayerPrefs.GetInt(vidaPrefsName, 80);
    }
}
