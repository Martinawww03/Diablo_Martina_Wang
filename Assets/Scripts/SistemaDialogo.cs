using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    //Patron SINGLE-TON (Clase, profe)
    //Static = (su valor puede cambiaar) que pertenece a la clase
    public static SistemaDialogo sistema;

    public static SistemaDialogo sD;
    public static EventManagerSO eventManager;

    [SerializeField] private GameObject marcoDialogo; //Marco a habilitar/deshabilitar
    [SerializeField] private TMP_Text textoDialogo; //El texto donde se veran reflejados los dialogps
    [SerializeField] private Transform npcCamera; // Camera compartida por todos los npc

    private bool escribiendo;
   
    private int indiceFraceActual = 0;

    private DialogoSO dialogoActual; //Para saber en todo momento cuál es el dialogo con el que estamos

    // Start is called before the first frame update
    //Awake se ejecuta ANTES del start() independientemente de que el gameObject esté activo o no
    void Awake()
    {
        //Si el trono está libre...
        if(sistema == null)
        {
            //Me hago con el trono, y entonces SistemaDialogo SOY YO (this)
            sistema = this;

        }
        else
        {
            //Me han quitado el trono, por lo tanto, me mato (soy un falso rey)
            Destroy(this.gameObject);
        }
    }

    public void iniciarDialogo(DialogoSO dialogo, Transform cameraPoint)
    {
        Time.timeScale = 0;

        //El dialogo actual que tenemos que tratar es el que me pasan por parámetro.
        dialogoActual = dialogo;
        marcoDialogo.SetActive(true);

        //Posiciono la camera en el punto de este NPC
       // npcCamera.SetPositionAndRotation


        StartCoroutine(EscribirFrase());
    }

    //Sirve para escribir frase letra por letra.
    private IEnumerator EscribirFrase()
    {
        escribiendo = true;

        //Limpio el texto
        textoDialogo.text=string.Empty;

        //Desmenuzo la frase actual por caracteres por separado.
        char[] fraseEnLetras = dialogoActual.frases[indiceFraceActual].ToCharArray();

        foreach(char letra in fraseEnLetras) 
        {
            textoDialogo.text += letra;
            yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras);
            //WaitForSecondsRealtime; no se para si el tiempo esta congelado.

        }

        escribiendo =false;

    }

    //Sirve para autocompletar la frase
    private void CompletarFrase()
    {
        //Si me piden completar la frase entera, en el texto pongo la frase entera.
        textoDialogo.text = dialogoActual.frases[indiceFraceActual];

        //Y paro las corrutinas que puedan estar vivas
        StopAllCoroutines();
        escribiendo = false;
    }

    private void SiguienteFrase()
    {
        if(!escribiendo) //Si NO estoy escribiendo
        {
          indiceFraceActual++; //Entonces, avanzo a la siguiente frase.

            //Si aún me quedan frases por sacar
          if(indiceFraceActual<dialogoActual.frases.Length)
          {
                //La escirbo
           StartCoroutine(EscribirFrase());

          }
          else
          {
                FinalizarDialogo();

          }

        }
        else
        {
            CompletarFrase();
        }
    }
    private void FinalizarDialogo()
    {
        Time.timeScale = 1f;
        marcoDialogo.SetActive(false); //Cerramos el marco de dialogo
        indiceFraceActual = 0; //para que en 
        StopAllCoroutines();

        if(dialogoActual.tieneMision)
        {
            //event
        }
        
        dialogoActual = null; //Ya no tengo dialogo que escribir
        
        
    }
    
}
