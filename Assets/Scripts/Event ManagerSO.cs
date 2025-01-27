using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu(menuName ="EventManager")]
public class EventManagerSO : ScriptableObject
{
    //Creo un evento.
    public event Action OnNuevaMision;

    //public void NuevaMision()
    //{
    //  //Lanzar/disparar el evento/
    //  OnNuevaMision.Invoke();
    //
    //}

}
