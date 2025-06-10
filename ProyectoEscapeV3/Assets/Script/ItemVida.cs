using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVida : MonoBehaviour, IInteractable
{
    [SerializeField] private Material material;
    [SerializeField] private float speed = 8;
    private float value;
    private bool desaparece = false;

    [SerializeField] private Material material2;
    public GameObject cerveza;

    void Start()
    {
        desaparece = false;
        GetComponent<Rigidbody>().AddForce(Vector3.up , ForceMode.Impulse);
        cerveza.GetComponent<MeshRenderer>().material = material2;
    }

    // Update is called once per frame
    void Update()
    {
        if (desaparece == true)
        {
            material.SetFloat("_CantidadNoise", 0);
            cerveza.GetComponent<MeshRenderer>().material = material;
            value = Mathf.Lerp(value, 1, Time.deltaTime * speed);
            material.SetFloat("_CantidadNoise", value);
            if (value >= 0.9 && value <= 0.91)
            {
                obliterar();
            }

        }
    }

    public void Interact()
    {
        if (desaparece == false)
        {
            ControladorItem.cantidadBoti++;
            desaparece = true;
        }
        
    }

    public void obliterar()
    {
        Destroy(this.gameObject);
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
}
