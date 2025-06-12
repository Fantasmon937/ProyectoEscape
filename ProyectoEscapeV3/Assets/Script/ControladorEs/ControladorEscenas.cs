using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscenas : MonoBehaviour
{
    //private String nextLVLPrefsName = "Next LVL";
    public static int nextLVL = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            reinicioEscena();
        }
    }

    public void cambioMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void cambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void cambiarNivel(string nombreEscena)
    {
        nextLVL = 1;
        SceneManager.LoadScene(nombreEscena);
    }

    public void reinicioEscena()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        PausaJuego.juegoPausa = false;
        PausaJuego.pausaConfig = false;

    }
}
