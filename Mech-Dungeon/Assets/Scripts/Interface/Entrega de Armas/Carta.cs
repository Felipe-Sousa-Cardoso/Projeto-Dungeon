using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carta : MonoBehaviour
{
    public CadaCarta carta;
    [SerializeField] Image Icone;
    [SerializeField] Image borda;
    [SerializeField] Sprite[] bordas;
    [SerializeField] Text Nome;
    [SerializeField] Text Descri��o;
    

    private void Start()
    {
        Icone.sprite = carta.sprite;
        borda.sprite = bordas[0];      
        Nome.text = carta.Nome;
        Descri��o.text = carta.Descricao;
    }
}
