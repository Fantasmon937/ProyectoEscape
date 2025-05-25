using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public GameObject jugador;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");

        jugador.transform.position = new Vector3(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"),
            PlayerPrefs.GetFloat("posZ"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void guardarPosicion()
    {
        PlayerPrefs.SetFloat("posX", jugador.transform.position.x);
        PlayerPrefs.SetFloat("posY", jugador.transform.position.y);
        PlayerPrefs.SetFloat("posZ", jugador.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            guardarPosicion();
        }
    }
}
