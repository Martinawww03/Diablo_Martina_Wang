using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;

    private List<Transform> listadosPuntos= new List<Transform>();  
    // Start is called before the first frame update

    private Transform[] array= new Transform[2];
    void Start()
    {
        foreach(Transform item in ruta)
        {
            Debug.Log(item.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
