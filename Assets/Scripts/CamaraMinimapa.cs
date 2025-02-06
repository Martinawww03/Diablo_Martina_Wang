using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMinimapa : MonoBehaviour
{

    [SerializeField] private PlayerOriginal player;

    private Vector3 distanciaAPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //Calculo la distancia inicial que hay entre el player y yo (cámara)
        distanciaAPlayer = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate() // el último metodo funciona
    {
        transform.position = player.transform.position + distanciaAPlayer;
    }
}
