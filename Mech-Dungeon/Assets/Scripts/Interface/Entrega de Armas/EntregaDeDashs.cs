using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EntregaDeDashs : MonoBehaviour
{
    [SerializeField] UsoDash[] ListaDeDashs;

    

    private void Start()
    {
        ListaDeDashs = Resources.LoadAll<UsoDash>("Dashs"); //carrega todos os dashs da pasta para a lista
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EmbaralharArray(ListaDeDashs);
        if (collision.tag == "Jogador")
        {
            UsoDash[] Lista = { ListaDeDashs[0], ListaDeDashs[1] };
            GerenciadorDeCartas.instancia.CriarCarta(collision.GetComponent<JogadorMovimento>(),Lista);
        }
    }
    void EmbaralharArray(UsoDash[] lista) //embaralha a lista
    {
        for (int i = 0; i < lista.Length; i++)
        {
            int rand = Random.Range(i, lista.Length);
            (lista[i], lista[rand]) = (lista[rand], lista[i]);
        }
        
    }

   

   
    
}
