using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToggleMision : MonoBehaviour
{
    [SerializeField] private TMP_Text textoMision;

    private Toogle toogleVisual;

    public TMP_Text TextoMision { get => textoMision;}
    internal Toogle ToogleVisual { get => toogleVisual;}
}

internal class Toogle
{

}