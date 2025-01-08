using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;

    //Almaceno el ultimo transform que clcke con el raton
    private Transform ultimoHit;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale==1)
        {
         Movimiento();

        }
        ComprobarInterracion();

    }

    private void Movimiento()
    {
        //Si clicko con el mouse izq
        if ((Input.GetMouseButtonDown(0)))
        {
            //Creo un rayo desde la cámara a la posición del ratón
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            //Y si ese rayo impacta en algo..
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                //Le decimos al agente (nosotros) que tiene como destino el punto de impacto
                agent.SetDestination(hitInfo.point);


                //Actualizo el ultimoHit con el transform que acabo de clickr
                ultimoHit = hitInfo.transform;
            }

        }
    }
    private void ComprobarInterracion()
    {
        //Si existe un interactuable al cual clické y lleva consigo el script Npc
        if(ultimoHit != null&&ultimoHit.TryGetComponent(out Npc npc))
        {
            //Actualizo distancia de parada para no "comerme" al Npc
            agent.stoppingDistance = 2f;

            //Mira a ver si hemos llegado a dicho destino.
            if(!agent.pathPending&&agent.remainingDistance<=agent.stoppingDistance)
            {
                //y por lo tanto, interatuo con el Npc, alt enter
                npc.Interactuar(this.transform);

                //me olvido de cual fue el ultimo click, porque solo quiere intectuar UNA VEZ.
                ultimoHit = null;

            }

            //Si no es un NPC, si no que es un click en el suelo...
            else if(ultimoHit)
            {
                //Reseteo el stoppingDIS original
                agent.stoppingDistance = 0f;
            }
        
        }
    }   
}
