using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMov : MonoBehaviour
{

    public static float movX, movZ;
    [SerializeField]
    private float velMov = 1;
    private Rigidbody rb;

    [SerializeField] private float multSprint = 350;

    public static float multiplicadorVel = 1;

    public Transform orientacion;
    Vector3 direccionMovimiento;

    private Animator anima;

    public ControlarAudio controAU;

    void Start()
    {
        multiplicadorVel = 1;
        rb = this.GetComponent<Rigidbody>();
        anima = GetComponent<Animator>();

    }

    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        direccionMovimiento = orientacion.forward * movZ + orientacion.right * movX;

        anima.SetFloat("X", movX);
        anima.SetFloat("Y", movZ);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            multSprint = velMov * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            multSprint = velMov;
        }


        if (movX == 0 && movZ == 0)
        {
            controAU.pasos.Stop();
        }
        else
        {
            if (controAU.pasos.isPlaying == false)
            {
                controAU.pasos.Play();
            }
            
        }

    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector3(direccionMovimiento.x * velMov * multiplicadorVel * Time.fixedDeltaTime, rb.velocity.y, direccionMovimiento.z * velMov * multiplicadorVel * Time.fixedDeltaTime);

        float velocidadTotal = (velMov + multSprint) * multiplicadorVel * Time.fixedDeltaTime;
        rb.velocity = new Vector3(direccionMovimiento.x * velocidadTotal, rb.velocity.y, direccionMovimiento.z * velocidadTotal);
    }



}
