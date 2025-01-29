using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Misión")]

public class MisionSO : MonoBehaviour
{
    public string ordenInicial; //Mensaje incial.
    public string ordenFinal; //Mensaje victoria.
    public bool tieneRepiticion; // (0/15)
    public int totalRepeticion; //veces que tengo que repetir ese paso. (0/8)
    public int indiceMision; //indice unico que representa a cada mision.

    [NonSerialized] 
    public int repeticionActual; // (3/8)


}
