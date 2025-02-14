using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "cadaArma", menuName = "Interface/Arma")]
public class DadosDaArma : ScriptableObject
{
    public Sprite sprite;
    public float CDrecarga;
    public int MuniçãoAtual;
}
