using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "cadaArma", menuName = "Equipamentos/Armas")]
public class CadaArma : CadaCarta
{
    public List<CadaMod> Modificações = new List<CadaMod>();
    public int Modulo;
    public float Cadencia;
    public float Alcance;
    public int Velocidade;
    public float Precisão;
    public int Pente;
    public float Recarga;
    public float Dano;
    public int muniçãoAtual;
    public int MuniçõesPorDisparo;
}
