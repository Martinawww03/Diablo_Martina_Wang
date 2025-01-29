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

    public void Interactuar()
    {
        eventManager.ActualizarMision(mision);
        Destroy(gameObject);
    }
}
