using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMIsiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private GameObject[] tooglesMision; 

    private void OnEnable()
    {
        //Me suscribo al evento y lo vinculo con el método.
        eventManager.OnNuevaMision += EncenderToggleMision;
    }

    private void EncenderToggleMision()
    {
        throw new System.NotImplementedException();
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
