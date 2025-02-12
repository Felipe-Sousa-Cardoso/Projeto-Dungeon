using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "cadaArma", menuName = "Equipamentos/Armas")]
public class CadaArma : CadaCarta
{
    public int[] Modificações;
    public int Modulo;
    public float Cadencia;
    public float Alcance;
    public float Precisão;
    public int Pente;
    public float Recarga;
    public float Dano;   
    public int MuniçõesPorDisparo;
}
