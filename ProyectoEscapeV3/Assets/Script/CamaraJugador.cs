using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraJugador : MonoBehaviour
{
    [Header("Reference")]
    public Transform orientacion;
    public Transform jugador;
    public Transform jugaadorObj;
    public Rigidbody rb;
    public CinemachineFreeLook camara;
    public int sensibilidad=500;

    public static float movXHor, movZVer;
    public float velocidadRotar;

    public Transform miraLook;
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if(PausaJuego.juegoPausa == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (PausaJuego.juegoPausa == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        camara.m_XAxis.m_MaxSpeed = sensibilidad;

        /*
        Vector3 vistaDireccion = jugador.position - new Vector3(transform.position.x, jugador.position.y, transform.position.z);
        orientacion.forward = vistaDireccion.normalized;

        movXHor = Input.GetAxis("Horizontal");
        movZVer = Input.GetAxis("Vertical");


        Vector3 direccionInput = orientacion.forward * movZVer + orientacion.right * movXHor;

        if (direccionInput != Vector3.zero)
        {
            
            jugaadorObj.forward = Vector3.Slerp(jugaadorObj.forward, direccionInput.normalized, Time.deltaTime * velocidadRotar);
        }
        */
        Vector3 vistaCombate = miraLook.position - new Vector3(transform.position.x, miraLook.position.y, transform.position.z);
        orientacion.forward = vistaCombate.normalized;

        jugaadorObj.forward = vistaCombate.normalized;
    }
}
