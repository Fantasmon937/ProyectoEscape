using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaZomb : MonoBehaviour
{
    private int vida = 2;
    private MoveZomb enemigo;
    public GameObject[] objetosDrop;
    private bool vivo = true;
    public Material color;
    private CapsuleCollider hitbox;

    void Start()
    {
        noDamage();
        enemigo = GetComponentInParent<MoveZomb>();
        hitbox = GetComponent<CapsuleCollider>();
    }


    void Update()
    {
        //Debug.Log("Enemigo Vida: " + vida);
        if (vivo)
        {
            if (vida <= 0)
            {
                enemigo.vivo = false;
                vivo = false;
                enemigo.autoDestruccion();
                hitbox.enabled = false;

                int aleatorio = Random.Range(0, 100);
                if (aleatorio >= 0 && Arma.municion <= 3)
                {
                    Instantiate(objetosDrop[2], this.transform.position + new Vector3(0, 0, 0), this.transform.rotation);

                }
                if (aleatorio >= 25)
                {
                    
                    Instantiate(objetosDrop[0], this.transform.position + new Vector3(0, 0, 0), this.transform.rotation);
                    
                }
                if (aleatorio >= 45)
                {
                    Instantiate(objetosDrop[2], this.transform.position + new Vector3(0, 0, 0), this.transform.rotation);   
                    Instantiate(objetosDrop[1], this.transform.position + new Vector3(0, 0, 0), this.transform.rotation);

                }
                if (aleatorio >= 90)
                {
                    Instantiate(objetosDrop[3], this.transform.position + new Vector3(0, 0, 0), this.transform.rotation);

                }

            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BalaJugador"))
        {
            vida--;
            damage();
            Invoke("noDamage",0.1f);

        }
    }

    public void damage()
    {
        if (vida > 0)
            color.SetColor("_BaseColor", new Color(0.91f, 0.3f, 0.21f));
    }

    public void noDamage()
    {
        color.SetColor("_BaseColor", new Color(1,1,1));
    }
}
