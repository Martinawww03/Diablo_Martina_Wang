using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour, IInteractuable
{
    [SerializeField] private DialogoSO dialogo1;
    [SerializeField] private DialogoSO dialogo2;
    [SerializeField] private DialogoSO dialogoActual;
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private MisionSO miMision;
    [SerializeField] private DialogoSO miDialogo;
    [SerializeField] private float duracionRotacion;
    [SerializeField] private Transform cameraPoint; //punto en el que se pondrá cameraNPC

    public void Awake()
    {
        dialogoActual = dialogo1;
    }
    private void OnEnable()
    {
        eventManager.OnTerminarMision += CambiarDialogo; ;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if(miMision==misionTerminada)
        {
            dialogoActual = dialogo2;
        }
    }

    public void Interactuar(Transform interactuador)
    {
        //Poco a poco voy rotando hacia el interactuador y CUANDO TERMINE de rotarme.. se inicia la interaccion
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete(IniciarInterracion);
    }

    // Start is called before the first frame update

    private void IniciarInterracion()
    {
        SistemaDialogo.sistema.iniciarDialogo(miDialogo,cameraPoint);
    }
    
    
}
