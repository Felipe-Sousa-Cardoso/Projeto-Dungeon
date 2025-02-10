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
    public void CriarCarta (JogadorMovimento jog, params UsoDash[] cartas )
    {
       
        for ( int i = 0; i < cartas.Length; i++ )
        {             
            carta.GetComponent<Carta>().carta = cartas[i].Valores;
            carta.GetComponent<Carta>().jog = jog;
            carta.GetComponent<Carta>().dah = cartas[i];

            int rand = Random.Range(0, 100); //Roleta a qualidade da carta
            switch (rand)
            {
                case int n when (n < 50): Debug.Log("Qualidade normal"); carta.GetComponent<Carta>().qualidade = 0; break;
                case int n when (n < 80): Debug.Log("Qualidade exelente"); carta.GetComponent<Carta>().qualidade = 1; break;
                case int n when (n <= 100): Debug.Log("Qualidade épica"); carta.GetComponent<Carta>().qualidade = 2; break;
            }
            rand = Random.Range(0, 100); //Roleta o atributo da carta
            switch (rand)
            {
                case int n when (n < 40): Debug.Log("Sem Atributo"); carta.GetComponent<Carta>().atributo = 0; break;
                case int n when (n < 60): Debug.Log("Veloz"); carta.GetComponent<Carta>().atributo = 1; break;
                case int n when (n < 80): Debug.Log("Potente"); carta.GetComponent<Carta>().atributo = 2; break;
                case int n when (n <= 100): Debug.Log("Versáril"); carta.GetComponent<Carta>().atributo = 3; break;
            }

            GameObject inst;
            switch (i)
            {
                case 0: inst = Instantiate(carta, Canvas); inst.transform.localPosition = new Vector3(-200, 0, 0);  break; 
                case 1: inst = Instantiate(carta, Canvas); inst.transform.localPosition = new Vector3(200, 0, 0);  break;
            }
            
 
        }
    }
}
