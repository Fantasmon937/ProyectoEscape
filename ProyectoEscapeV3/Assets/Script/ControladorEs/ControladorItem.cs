using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControladorItem : MonoBehaviour
{
    public TextMeshProUGUI textCantidadCer;
    public static int cantidadCer = 1;
    public TextMeshProUGUI textCantidadVend;
    public static int cantidadVend = 1;
    public TextMeshProUGUI textCantidadBoti;
    public static int cantidadBoti = 1;

    private VidaJugador jugador;

    void Start()
    {
        cantidadBoti = 1;
        cantidadCer = 1;
        cantidadVend = 1;
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
            }
            if (cantidadVend > 0 && Input.GetKeyDown(KeyCode.Alpha2))
            {
                usarItemVen();
            }
            if (cantidadBoti > 0 && Input.GetKeyDown(KeyCode.Alpha3))
            {
                usarItemBoti();
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
        //JugadorMov.multiSaltoFu = 1.5f;
        //Invoke(nameof(restablecerSalto), 3);
    }

    /*private void restablecerSalto()
    {

        JugadorMov.multiSaltoFu = 1;

    }*/

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
}
