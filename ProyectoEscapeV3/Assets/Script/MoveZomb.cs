using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveZomb : MonoBehaviour
{
    private GameObject jugadorObjetivo;
    private NavMeshAgent agent;
    public Transform[] puntosDestino;
    private int indice = 0;
    public bool perseguir = false;

    private Animator anima;

    public bool vivo = true;

    public bool atacando = false;
    private float contadorTiempo = 0;
    private float tiempoEntreGolpe = 0.3f;
    private VidaJugador jugador;

    public AudioSource zombie1;
    public AudioSource zombie2;
    public AudioSource atacar;

    private float contaTiempAtac = 0;
    private float tiempEntreAtac = 5;

    void Start()
    {
        jugadorObjetivo = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(puntosDestino[0].position);
        anima = GetComponent<Animator>();

        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<VidaJugador>();


    }

    void Update()
    {

        if (PausaJuego.juegoPausa == false)
        {
            if (atacando && vivo)
            {
                zombie1.Stop();
                zombie2.Stop();
                if (atacar.isPlaying == false)
                {
                    atacar.Play();
                }
                agent.velocity = new Vector3(0, 0, 0);
                contadorTiempo += Time.deltaTime;

                if (contadorTiempo >= tiempoEntreGolpe)
                {
                    jugador.perderVida(4);
                    contadorTiempo = 0;
                }
            }

            if (vivo )
            {
                anima.SetBool("muerto", false);
                if (!perseguir)
                {
                    contaTiempAtac += Time.deltaTime + Random.Range(-0.4f, 0.4f);



                    if (contaTiempAtac >= tiempEntreAtac && zombie1.isPlaying == false && zombie2.isPlaying == false)
                    {

                        int aleatorio = Random.Range(0, 4);

                        if (aleatorio == 1)
                        {
                            zombie1.Play();
                        }
                        else if (aleatorio == 2)
                        {
                            zombie2.Play();
                        }
                        contaTiempAtac = 0;
                    }
                    atacar.Stop();
                    agent.speed = 2;

                    if (agent.remainingDistance < 0.5f)
                    {
                        indice++;
                    }

                    if (indice >= puntosDestino.Length)
                    {
                        indice = 0;
                    }
                    agent.SetDestination(puntosDestino[indice].position);
                    anima.SetInteger("caminar", 1);

                }
                else
                {
                    zombie1.Stop();
                    zombie2.Stop();

                    if (atacar.isPlaying == false)
                    {
                        atacar.Play();
                    }
                    if (agent.remainingDistance <= 1f && atacando == false)
                    {
                        agent.velocity = new Vector3(0, 0, 0);
                        anima.SetInteger("caminar", 0);
                    }
                    else
                    {
                        agent.speed = 13;
                        anima.SetInteger("caminar", 2);

                    }
                    agent.SetDestination(jugadorObjetivo.transform.position);


                }


            }
            else
            {
                agent.speed = 0;
                agent.velocity = Vector3.zero;
                //anima.SetInteger("caminar", 0);
                anima.SetBool("muerto", true);
                jugador.noDamage();
            }
        }
        else
        {
            atacar.Stop();
            zombie1.Stop();
            zombie2.Stop();
            jugador.noDamage();
        }
        

    }

    public void autoDestruccion()
    {
        atacar.Stop();
        zombie1.Stop();
        zombie2.Stop();
        Destroy(this.gameObject, 3.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            agent.velocity = new Vector3(0, 0, 0);
            collision.gameObject.GetComponent<VidaJugador>().perderVida(4);
            atacando = true;
            jugador.damage();

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            atacando = false;
            jugador.noDamage();

        }
    }

}

