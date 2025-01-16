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
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private float danhoAtaque;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        main.Combate = this;
    }
    private void OnEnable()
    {
        agent.speed = velocidadCombate;
        agent.stoppingDistance = distanciaAtaque;
    }

    //OnEnable: Se ejecuta cuando se activa el SCRIPTS
    private void Update()
    {
        //Sólo si existe un objectivo..
        if(main.Target!=null && agent.CalculatePath(main.Target.position,new NavMeshPath()))
        {
            //Procuraremos al objectivo
            EnfocarObjetivo();
            agent.SetDestination(main.Target.position);
                
            //Cuando tenga el objectivo a distancia de ataque..
            if(agent.pathPending&&agent.remainingDistance<=distanciaAtaque)
            {
               
                //anim.SetBool("attaking",true);
            }


        }
        else
        {
            main.ActivarPatrulla();
        }
    }
    private void EnfocarObjetivo()
    {
        //1. Calculo la dirección al objetivo
        Vector3 direccionATarget=(main.Target.transform.position-transform.position).normalized;
        direccionATarget.y=0f; //Pongo la 'y' a 0 para que no se vuelque

        //Transformo una dirección en una rotación 
        Quaternion rotacionATarget = Quaternion.LookRotation(direccionATarget);

        transform.rotation = rotacionATarget;
    }

    #region Ejecutador por evento de animación
    private void Atacar()
    {
        //HAcer daño al target.
        main.Target.GetComponent<Player>().HacerDanho();
    }
    private void FinAnimacionAtaque()
    {
        anim.SetBool("attacking", false);
    }
    #endregion
}
