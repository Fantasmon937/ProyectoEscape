using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class AjustesGuardados : MonoBehaviour
{
    public Slider barraVolum;   
    public TextMeshProUGUI textoVolum;
    public TMP_Dropdown pantalla;

    private void Awake()
    {
        cargarConfig();
    }
    void Start()
    { 
        
    }

    private void OnDestroy()
    {
        guardarConfig();
    }
    void Update()
    {
        textoVolum.text = "Volumen: " + barraVolum.value;
    }

    public void guardarConfig()
    {
        PlayerPrefs.SetInt("volum", (int)barraVolum.value);
        PlayerPrefs.SetInt("resolucion", pantalla.value);
    }

    public void cargarConfig()
    {
        pantalla.value = PlayerPrefs.GetInt("resolucion",0);
        barraVolum.value = PlayerPrefs.GetInt("volum",0);
    }

}
