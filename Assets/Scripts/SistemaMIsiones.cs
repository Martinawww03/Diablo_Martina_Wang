using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMIsiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private GameObject[] tooglesMision; 
    private void EncenderToggleMision(MisionSO mision)
    {
        //Alimentos el texto con el contenido de la misión
        //tooglesMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;

        //Y si tiene repetición..
        if(mision.tieneRepiticion)
        {
          //  togglesMision[mision.indiceMision].TextoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticion + ")";
        }

        tooglesMision[mision.indiceMision].gameObject.SetActive(true);// Enciendo el toggle para que se vea en pantalla.

    }

    private void ActualizarToggleMision(MisionSO mision)
    {
        //Apuntes
        //togglesMision[mision.indiceMision].TextoMision.text = mision.ordenIncial;
        //togglesMision[mision.indiceMision].TextoMision.text += "("+ mision.repeticionActual+
    }

    //private void ActualizarToggleMision(MisionSO obj)
    //{
    //    throw new System.NotImplementedException();
    //}


   
}
