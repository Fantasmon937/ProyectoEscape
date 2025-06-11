using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinJuego : MonoBehaviour
{
    [SerializeField] private GameObject menuLose;

    void Start()
    {
        if (PausaJuego.juegoPausa == false)
        {
            menuLose.SetActive(false);
        }
        

    }

    // Update is called once per frame
    void Update()
    {

        if (VidaJugador.vida<=0 || ControladorJuego.tiempoTerminado==true)
        {
            menuLose.SetActive(true);
            PausaJuego.juegoPausa = true;
            Time.timeScale = 0;
            VidaJugador.vida = 80;
        }
    }
}
