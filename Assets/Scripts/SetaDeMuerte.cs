using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaDeMuerte : MonoBehaviour, IInteractuable
{
    private Outline outline;

    [SerializeField] private MisionSO mision;

    [SerializeField] private EventManagerSO eventManager;

    private void Awake()
    {
        outline= GetComponent<Outline>();
    }

    private void OnMouseEnter()
    {
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }

    public void Interactuar(Transform interactor)
    {
        mision.repeticionActual++;

        //Todavía quedan setas por recoger
        if(mision.repeticionActual<mision.totalRepeticion)
        {
            eventManager.ActualizarMision(mision);
        }
        else //Ya hemos terminado de recoger todas las setas.
        {
            eventManager.TerminarMision(mision);
        }
        Destroy(gameObject);
    }
}
