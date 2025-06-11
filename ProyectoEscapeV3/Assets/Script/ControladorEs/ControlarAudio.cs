using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlarAudio : MonoBehaviour
{

    public AudioSource disparo;
    public AudioSource pasos;
    public AudioSource recarga;
    public AudioSource sinMunicion;
    public AudioSource golpe;
    public AudioSource ambiente;

    void Start()
    {
        ambiente.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }






}
