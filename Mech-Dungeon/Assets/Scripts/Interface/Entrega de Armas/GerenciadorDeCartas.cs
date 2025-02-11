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
                case int n when (n < 50): carta.GetComponent<Carta>().qualidade = 0; break;
                case int n when (n < 80): carta.GetComponent<Carta>().qualidade = 1; break;
                case int n when (n <= 100): carta.GetComponent<Carta>().qualidade = 2; break;
            }
            rand = Random.Range(0, 100); //Roleta o atributo da carta
            switch (rand)
            {
                case int n when (n < 40): carta.GetComponent<Carta>().atributo = 0; break;
                case int n when (n < 60): carta.GetComponent<Carta>().atributo = 1; break;
                case int n when (n < 80): carta.GetComponent<Carta>().atributo = 2; break;
                case int n when (n <= 100): carta.GetComponent<Carta>().atributo = 3; break;
            }

            GameObject inst; //Seleciona a carta que foi instanciada para poder alterar sua posição
            switch (i)
            {
                case 0: inst = Instantiate(carta, Canvas); inst.transform.localPosition = new Vector3(-200, 0, 0); break;
                case 1: inst = Instantiate(carta, Canvas); inst.transform.localPosition = new Vector3(200, 0, 0); break;
            }            
        }
    }
    public void Sumir()
    {
        foreach (Transform filho in this.transform)
        {
            filho.gameObject.SetActive(false);
        }

    } //Controla as cartas, é chamado externamente
    public void Destruir()
    {
        foreach (Transform filho in this.transform)
        {
            Destroy(filho.gameObject);
        }
        Resources.UnloadUnusedAssets();
    }//Controla as cartas, é chamado externamente
    public void Aparecer()
    {
        foreach (Transform filho in this.transform)
        {
            filho.gameObject.SetActive(true);
        }

    }//Controla as cartas, é chamado externamente
}
