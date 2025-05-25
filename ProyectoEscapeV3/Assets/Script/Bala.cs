using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidadMovimiento;

    void Start()
    {
        Destroy(this.gameObject, 2);
    }

    void Update()
    {
        this.transform.Translate(Vector3.forward * velocidadMovimiento * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
    }
}
