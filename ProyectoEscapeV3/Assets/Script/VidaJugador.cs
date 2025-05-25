using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    public static int vida = 100;
    public Slider barraVida;
    public TextMeshProUGUI textVida;
    public Material color;

    void Start()
    {
        vida = 50;
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
        color.SetColor("_BaseColor", new Color(0.91f, 0.3f, 0.21f));
    }
    public void noDamage()
    {
        color.SetColor("_BaseColor", Color.white);
    }

    public void curar()
    {
        color.SetColor("_BaseColor", new Color(0.41f, 0.81f, 0.41f));
    }
}
