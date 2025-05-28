using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControladorLibros : MonoBehaviour
{
    public TextMeshProUGUI textMostrarLibros;

    void Start()
    {
        textMostrarLibros.text = "Libros: " + Libros.contadorLibros + " /5";
    }

    // Update is called once per frame
    void Update()
    {
        textMostrarLibros.text = "Libros: " + Libros.contadorLibros + " /5";
    }
}
