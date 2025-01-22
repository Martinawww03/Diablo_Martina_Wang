using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;
    [SerializeField] private Enemigo main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float velocidadPatrulla;

    private List<Transform> listadosPuntos= new List<Transform>();

    private int indiceDestinoActual = -1; //MArca el punto al cual debo ir.

    private Transform destinoActual; //Marco el destino al cual debo ir.

    private void Awake()
    {
        foreach(Transform t in ruta)
        {
            // Añado todos los puntos de ruta al listado.

            listadosPuntos.Add(t);
        }
    }

    private void OnEnable()
    {
        //El stoppingDistance vuelve a ser 0
        agent.stoppingDistance = 0;
        agent.speed = velocidadPatrulla; //Vuelvo a la velocidad de patrulla.
        StartCoroutine(PatruillarYEsperar());

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

            //Espera una vez llegado al punto entre 0.25 y 3 segundos.
            yield return new WaitForSeconds(Random.Range(0.25f, 3f));

        }
    }
    private bool Ejemplo()
    {
        return agent.remainingDistance <= 0;
    }

    private void CalcularDestino()
    {
        indiceDestinoActual++;

        //Si nos hemos quedados sin puntos...
        if(indiceDestinoActual > listadosPuntos.Count)
        {
            indiceDestinoActual = 0; 
        }
        destinoActual = listadosPuntos[indiceDestinoActual];
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StopAllCoroutines(); //Abandonamis la corrutina de patrulla.

            //Le digo a 'main' que active el combate, pasándole el objetivo al que tiene que 
            main.ActivarCombate(other.transform);
        }
    }

}
