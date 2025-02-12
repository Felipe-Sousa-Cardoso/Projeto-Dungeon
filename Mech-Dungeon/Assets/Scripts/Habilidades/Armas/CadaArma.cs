using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "cadaArma", menuName = "Equipamentos/Armas")]
public class CadaArma : CadaCarta
{
    public int[] Modifica��es;
    public int Modulo;
    public float Cadencia;
    public float Alcance;
    public float Precis�o;
    public int Pente;
    public float Recarga;
    public float Dano;   
    public int Muni��esPorDisparo;
}
