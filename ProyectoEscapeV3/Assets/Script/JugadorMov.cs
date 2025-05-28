using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMov : MonoBehaviour
{

    public static float movX, movZ;
    [SerializeField]
    private float velMov = 1;
    private Rigidbody rb;
    [SerializeField] private float multSprint;

    public static float multiplicadorVel = 1;

    public Transform orientacion;
    Vector3 direccionMovimiento;

    private Animator anima;

    //-Funciones No necesarias para el juego final

    /*private bool saltar;
    private bool puedeSal = true;
    public float fuerzaSalto;

    public static float multiSaltoFu = 1;
    private int multiSalt = 2;

    private float tiempoCoyote = 0.2f;
    private bool coyoteTime;
    private float temporizadorCoyote;
    private bool yaSalto = false;*/

    void Start()
    {
        //multiSaltoFu = 1;
        multiplicadorVel = 1;
        rb = this.GetComponent<Rigidbody>();
        anima = GetComponent<Animator>();
        multSprint = velMov;
    }

    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        direccionMovimiento = orientacion.forward * movZ + orientacion.right * movX;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            multSprint = velMov * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            multSprint = velMov;
        }

        if (movX != 0 || movZ != 0)
        {
            anima.SetInteger("velocidad", 1);
        }
        else
        {
            anima.SetInteger("velocidad", 0);
        }
        

        //--Cosas No necesarias para el juego final

        /*if (!puedeSal && coyoteTime && !yaSalto)
        {
            temporizadorCoyote += Time.deltaTime;
            if (temporizadorCoyote > tiempoCoyote)
            {
                Debug.Log("Se termino Coyote");
                coyoteTime = false;
                multiSalt = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && multiSalt > 0 && PausaJuego.juegoPausa==false)
        {
            saltar = true;

            
        }*/
    }

    private void FixedUpdate()
    {
        float velocidadTotal = (velMov + multSprint) * multiplicadorVel * Time.fixedDeltaTime;
        rb.velocity = new Vector3(direccionMovimiento.x * velocidadTotal, rb.velocity.y, direccionMovimiento.z * velocidadTotal);


        // -- Cosas no necesarias para el juego final
       /* if (saltar && multiSalt > 0 && coyoteTime)
        {
            //anima.SetBool("salte", true);
            anima.SetTrigger("saltar");
            yaSalto = true;
            rb.AddForce(Vector3.up * fuerzaSalto * multiSaltoFu * Time.fixedDeltaTime, ForceMode.Impulse);
            multiSalt--;
            saltar = false;

        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Suelo"))
        {
            // -- Cosas no necesarias para el juego final
            /* yaSalto = false;
             puedeSal = true;
             coyoteTime = true;
             temporizadorCoyote = 0;
             multiSalt = 2;*/
            //anima.SetBool("suelo", true);
            //Debug.Log("Puede saltar? - " + puedeSal);

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Suelo"))
        {
            // -- Cosas no necesarias para el juego final
            //puedeSal = true;
            //.SetBool("suelo", true);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Suelo"))
        {
            
            //puedeSal = false;
            //anima.SetBool("suelo", false);
        }
    }

}
