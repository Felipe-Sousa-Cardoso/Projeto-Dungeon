using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "cadaArma", menuName = "Interface/Arma")]
public class DadosDaArma : ScriptableObject
{
    public Sprite sprite;
    public Sprite proxmoSprite;
    public float CDrecarga;
    public int MuniçãoAtual;
    public bool recarregando; //verifica quando o jogador está recarregando
}
