using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    
    public TextMeshProUGUI textTiempo;
    public TextMeshProUGUI textLevel;
    [SerializeReference]private float tiempo = 0;
    [SerializeField] private GameObject textoPick;
    public static bool interactua = false;

    private int tiempoMinut, tiempoSeg, tiempoDeci;

    public static bool tiempoTerminado=false;

    private string nivelAct;

    void Start()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        nivelAct = SepararConRegex(currentScene.name);

        textLevel.text = nivelAct;
        //textLevel.text = currentScene.name;
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

    string SepararConRegex(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        return Regex.Replace(input, @"(\D+)(\d+)", "$1 $2");
    }


}
