using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;

    private NavMeshAgent agent;

    private List<Transform> listadosPuntos= new List<Transform>();

    private int indiceDestinoActual = 0; //MArca el punto al cual debo ir.

    private Transform destinoActual; //Marco el destino al cual debo ir.

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        foreach(Transform t in ruta)
        {
            // Añado todos los puntos de ruta al listado.

            listadosPuntos.Add(t);
        }
    }


    private Transform[] array= new Transform[2];
    private void Start()
    {
        StartCoroutine(PatruillarYEsperar());
    }

    private IEnumerator PatruillarYEsperar()
    {
        //Por siempre
        while(true)
        {

            CalcularDestino(); //Tendré que calcular el nuevo destido
            
            agent.SetDestination(destinoActual.position);
          yield return new WaitUntil(() => agent. remainingDistance<=0); // () ES: expresión lambda (MÉTODO ANONIMO) 

        }
    }

    private void CalcularDestino()
    {
        indiceDestinoActual++;

        //Si nos hemos quedados sin puntos...
        if(indiceDestinoActual> listadosPuntos.Count)
        {
            indiceDestinoActual = 0; 
        }
        destinoActual = listadosPuntos[indiceDestinoActual];
    }
    
}
