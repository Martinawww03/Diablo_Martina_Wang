using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] private DialogoSO miDialogo;
    [SerializeField] private float duracionRotacion;
    [SerializeField] private Transform cameraPoint; //punto en el que se pondrá cameraNPC
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
