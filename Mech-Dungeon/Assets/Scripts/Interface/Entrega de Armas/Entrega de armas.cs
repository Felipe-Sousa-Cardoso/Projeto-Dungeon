using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntregaDeArmas : MonoBehaviour
{
    [SerializeField] List<UsoDash> ListaDeDashs = new List<UsoDash>();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        EmbaralharLista(ListaDeDashs);
    }
    void EmbaralharLista(List<UsoDash> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            int rand = Random.Range(i, lista.Count);
            (lista[i], lista[rand]) = (lista[rand], lista[i]);
        }
        
    }

   
    
}
