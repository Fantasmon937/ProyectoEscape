using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class InteraccionItem : MonoBehaviour
{
    public Transform interactorSource;
    public float rangoInteraccion;
    public Transform origen;
    public LayerMask ignoreLayer;
    public float anguloDesplazamiento = 0.2f;
    public float anguloDesplazY = 0.2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origenAjustado = origen.position + new Vector3(0, 0.5f, -0.5f);
        Vector3 direccionAjustada = (interactorSource.forward
                                    + interactorSource.right * anguloDesplazamiento
                                    - interactorSource.up * anguloDesplazY).normalized;


        if (PausaJuego.juegoPausa == false) {
            Ray r = new Ray(origenAjustado, direccionAjustada);

            if (Physics.SphereCast(r, 0.2f, out RaycastHit hit, rangoInteraccion,ignoreLayer) && hit.transform.gameObject.tag == "ObjetoItem")
            {
                ControladorJuego.interactua = true;
                Debug.DrawRay(r.origin , r.direction * rangoInteraccion, Color.green);
            }
            else
            {
                ControladorJuego.interactua = false;
                Debug.DrawRay(r.origin, r.direction * rangoInteraccion, Color.red);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Physics.SphereCast(r, 0.2f, out RaycastHit hitInfo, rangoInteraccion,ignoreLayer))
                {
                    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                    {

                        interactObj.Interact();
                    }
                }
            }
        }
        
    }

    /*void OnDrawGizmos()
    {
        if (origen == null || interactorSource == null) return;

        // Definir el rayo
        Vector3 origenAjustado = origen.position + new Vector3(0, 0.5f, -0.5f);
        Vector3 direccionAjustada = (interactorSource.forward
                                    + interactorSource.right * anguloDesplazamiento
                                    - interactorSource.up * anguloDesplazY).normalized;
        Ray r = new Ray(origenAjustado, direccionAjustada);

        // Dibujar la línea central del SphereCast
        Gizmos.color = Color.blue; // Línea azul para la trayectoria
        Gizmos.DrawRay(r.origin, r.direction * rangoInteraccion);

        // Dibujar la esfera en el punto de origen
        Gizmos.color = Color.yellow; // Esfera amarilla en el origen
        Gizmos.DrawWireSphere(r.origin, 0.2f);

        // Dibujar la esfera en el punto final (o donde golpea)
        bool hitSomething = Physics.SphereCast(r, 0.2f, out RaycastHit hit, rangoInteraccion);
        Vector3 endPoint = hitSomething ? hit.point : r.origin + r.direction * rangoInteraccion;
        Gizmos.color = hitSomething ? Color.green : Color.red; // Verde si golpea, rojo si no
        Gizmos.DrawWireSphere(endPoint, 0.2f);
    }*/
}
