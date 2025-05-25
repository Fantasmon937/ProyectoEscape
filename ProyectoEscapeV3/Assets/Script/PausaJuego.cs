using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaJuego : MonoBehaviour
{
    public static bool juegoPausa = false;
    public static bool pausaConfig = false;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menuPausaConfig;

    void Start()
    {
        quitarPausa();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && juegoPausa == false && pausaConfig == false)
        {
            pausa();

        }else if (Input.GetKeyDown(KeyCode.P) && juegoPausa == true && pausaConfig == false)
        {
            quitarPausa();
        }

    }

    public void pausa()
    {
        Time.timeScale = 0;
        juegoPausa = true;
        menuPausa.SetActive(true);
        //menuPausaConfig.SetActive(false);
    }

    public void quitarPausa()
    {
        Time.timeScale = 1;
        juegoPausa = false;
        menuPausa.SetActive(false);
        //menuPausaConfig.SetActive(false);
    }

    public void config()
    {
        pausaConfig = true;
        menuPausa.SetActive(false);
        menuPausaConfig.SetActive(true);
    }

    public void quitarConfig()
    {
        pausaConfig = false;
        menuPausa.SetActive(true);
        menuPausaConfig.SetActive(false);
    }
}
