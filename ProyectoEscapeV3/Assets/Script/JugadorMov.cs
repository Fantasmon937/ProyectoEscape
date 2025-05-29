using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMov : MonoBehaviour
{

    public static float movX, movZ;
    [SerializeField]
    private float velMov = 1;
    private Rigidbody rb;

    public static float multiplicadorVel = 1;

    public Transform orientacion;
    Vector3 direccionMovimiento;

    private Animator anima;

    void Start()
    {
        //multiSaltoFu = 1;
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

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(direccionMovimiento.x * velMov * multiplicadorVel * Time.fixedDeltaTime, rb.velocity.y, direccionMovimiento.z * velMov * multiplicadorVel * Time.fixedDeltaTime);
    }


}
