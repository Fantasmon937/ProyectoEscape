using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarLvl : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject menuWin;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PausaJuego.juegoPausa==false)
        {
            menuWin.SetActive(false);
        }
    }

    public void Interact()
    {
        Scene escena = SceneManager.GetActiveScene();

        if (Libros.contadorLibros >= 5 || escena.name=="Muestra")
        {
            menuWin.SetActive(true);
            PausaJuego.juegoPausa = true;
            Time.timeScale = 0;
        }
        
    }
}
