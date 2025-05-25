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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PausaJuego.juegoPausa == false) {
            Ray r = new Ray(origen.position + new Vector3(0, 0.5f, -0.5f), interactorSource.forward);

            if (Physics.Raycast(r, out RaycastHit hit, rangoInteraccion) && hit.transform.gameObject.tag == "ObjetoItem")
            {
                ControladorJuego.interactua = true;
                //Debug.DrawRay(r.origin , r.direction * rangoInteraccion, Color.green);
            }
            else
            {
                ControladorJuego.interactua = false;
                //Debug.DrawRay(r.origin, r.direction * rangoInteraccion, Color.red);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Physics.Raycast(r, out RaycastHit hitInfo, rangoInteraccion))
                {
                    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                    {

                        interactObj.Interact();
                    }
                }
            }
        }
        
    }
}
