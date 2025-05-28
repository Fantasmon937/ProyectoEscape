using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    
    public TextMeshProUGUI textTiempo;
    [SerializeReference]private float tiempo = 0;
    [SerializeField] private GameObject textoPick;
    public static bool interactua = false;

    private int tiempoMinut, tiempoSeg, tiempoDeci;

    public static bool tiempoTerminado=false;

    void Start()
    {
        tiempoTerminado = false;
        tiempo = tiempo * 60;
    }

    // Update is called once per frame
    void Update()
    {
        Cronometro();
        if (interactua)
        {
            textoPick.SetActive(true);
        }
        else
        {
            textoPick.SetActive(false);
        }

    }
    void Cronometro()
    {
        if (!tiempoTerminado)
        {
            tiempo -= Time.deltaTime;
        }
        
        tiempoMinut = Mathf.FloorToInt(tiempo / 60);
        tiempoSeg = Mathf.FloorToInt(tiempo % 60);
        tiempoDeci = Mathf.FloorToInt((tiempo%1) * 100);

        textTiempo.text = string.Format("{0:00}:{1:00}:{2:00}", tiempoMinut, tiempoSeg, tiempoDeci);

        if (tiempo <= 0)
        {
            tiempo = 0;
            tiempoTerminado = true;

        }
    }


}
