using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Interfaz: Es una serie de m�todos que se han de implementar
// En aquellas entidades que, en este caso, sean interactuables
public interface IInteractuable
{
    public void Interactuar(Transform interactuador);
}
