using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarJugador : MonoBehaviour
{
    private MoveZomb enemigo;
    public Transform origen;
    public Transform interactorSource;
    public float rangoInteraccion;
    private bool paredT = false;


    void Start()
    {
        enemigo = GetComponentInParent<MoveZomb>();
    }

    void Update()
    {
        Ray r = new Ray(origen.position, interactorSource.forward);

        if (Physics.SphereCast(r, 3f, out RaycastHit hit, rangoInteraccion) && hit.transform.gameObject.CompareTag("Pared"))
        {
            if(enemigo.perseguir == false)
            {
                paredT = true;
            }
            //Debug.DrawRay(r.origin, r.direction * rangoInteraccion, Color.green);
        }
        else
        {
            paredT = false;
            //Debug.DrawRay(r.origin, r.direction * rangoInteraccion, Color.red);
        }
    }

    /*void OnDrawGizmos()
    {
        if (origen == null || interactorSource == null) return;

        // Definir el rayo
        Ray r = new Ray(origen.position, interactorSource.forward);

        // Dibujar la línea central del SphereCast
        Gizmos.color = Color.blue; // Línea azul para la trayectoria
        Gizmos.DrawRay(r.origin, r.direction * rangoInteraccion);

        // Dibujar la esfera en el punto de origen
        Gizmos.color = Color.yellow; // Esfera amarilla en el origen
        Gizmos.DrawWireSphere(r.origin, 3f);

        // Dibujar la esfera en el punto final (o donde golpea)
        bool hitSomething = Physics.SphereCast(r, 3f, out RaycastHit hit, rangoInteraccion);
        Vector3 endPoint = hitSomething ? hit.point : r.origin + r.direction * rangoInteraccion;
        Gizmos.color = hitSomething ? Color.green : Color.red; // Verde si golpea, rojo si no
        Gizmos.DrawWireSphere(endPoint, 3f);
    }*/

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && paredT==false)
        {
            enemigo.perseguir = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemigo.perseguir = false;
        }

    }
}
