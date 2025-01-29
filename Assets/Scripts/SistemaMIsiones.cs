using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMIsiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private GameObject[] tooglesMision; 

    private void OnEnable()
    {
        //Me suscribo al evento y lo vinculo con el m�todo.
        eventManager.OnNuevaMision += EncenderToggleMision;
    }

    private void EncenderToggleMision(MisionSO mision)
    {
        //Alimentos el texto con el contenido de la misi�n
        //tooglesMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;

        //Y si tiene repetici�n..
        if(mision.tieneRepiticion)
        {
          //  togglesMision[mision.indiceMision].TextoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticion + ")";
        }

        tooglesMision[mision.indiceMision].gameObject.SetActive(true);// Enciendo el toggle para que se vea en pantalla.

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
