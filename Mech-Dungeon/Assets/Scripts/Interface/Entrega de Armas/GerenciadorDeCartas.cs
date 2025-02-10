using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

 public class GerenciadorDeCartas : MonoBehaviour 
{
    public static GerenciadorDeCartas instancia;
    [SerializeField] GameObject carta;
    [SerializeField] Transform Canvas;

    void Start()
    {
        instancia = this;
    }
    public void CriarCarta (params CadaCarta[] cartas)
    {
        carta.GetComponent<Carta>().carta = cartas[0];
        Instantiate (carta,Canvas);
    }
}
