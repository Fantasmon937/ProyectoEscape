using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderGirar : MonoBehaviour
{
    [SerializeField]
    [Range(0, 30)]
    private float velocidadRotacion = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, velocidadRotacion * Time.deltaTime * 10, 0));
    }
}
