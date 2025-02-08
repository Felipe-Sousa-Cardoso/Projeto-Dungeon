using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntregaDeDashs : MonoBehaviour
{
    [SerializeField] UsoDash[] ListaDeDashs;

    private void Start()
    {
        ListaDeDashs = Resources.LoadAll<UsoDash>("Dashs");
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EmbaralharArray(ListaDeDashs);
        if (collision.tag == "Jogador")
        {
            collision.gameObject.GetComponent<JogadorMovimento>().GetSetDash = ListaDeDashs[0];
            collision.gameObject.GetComponent<JogadorMovimento>().UpdateDash();
        }
    }
    void EmbaralharArray(UsoDash[] lista)
    {
        for (int i = 0; i < lista.Length; i++)
        {
            int rand = Random.Range(i, lista.Length);
            (lista[i], lista[rand]) = (lista[rand], lista[i]);
        }
        
    }

    void EntregarDash()
    {

    }
    

   
    
}
