using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class itemCerveza : MonoBehaviour, IInteractable
{
    [SerializeField] private Material material;
    [SerializeField] private Material material2;
    [SerializeField] private float speed = 8;
    private float value;
    private bool desaparece = false;
    public GameObject cerveza;

    void Start()
    {
        desaparece = false;
        GetComponent<Rigidbody>().AddForce(Vector3.up , ForceMode.Impulse);
        cerveza.GetComponent<MeshRenderer>().material = material2;

    }
    void Update()
    {

        if (desaparece == true)
        {
            material.SetFloat("_CantidadNoise", 0);
            cerveza.GetComponent<MeshRenderer>().material = material;
            value = Mathf.Lerp(value, 1, Time.deltaTime * speed);
            material.SetFloat("_CantidadNoise", value);
            if (value >=0.9)
            {
                obliterar();
            }

        }
    }

    public void Interact()
    {
        if (desaparece == false)
        {
            ControladorItem.cantidadCer++;
            desaparece = true;
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo") || collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Collider>().isTrigger = true;
        }
    }

    public void obliterar()
    {
        Destroy(this.gameObject);
    }

    
}
