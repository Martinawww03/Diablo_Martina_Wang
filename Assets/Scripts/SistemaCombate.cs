using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float velocidadCombate;

    private void Awake()
    {
        main.Combate = this;
    }

    //OnEnable: Se ejecuta cuando se activa el SCRIPTS
    private void Update()
    {
        agent.speed = velocidadCombate;
        //Voy presiguiendo al target en todo momento (calculando...)
        agent.SetDestination(main.Target.position);
    }
}
