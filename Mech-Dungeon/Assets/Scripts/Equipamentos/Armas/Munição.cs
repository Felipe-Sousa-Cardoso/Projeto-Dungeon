using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Danificavel;

public class Munição : MonoBehaviour
{
    float dano;

    #region Metodos de Acesso
    public float Dano
    {
        get { return dano; }
        set { dano = value; }
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDanificavel objeto = collision.gameObject.GetComponent<IDanificavel>();
        if (objeto != null)
        {
            objeto.Danificar(dano);
        }
    }
    
}
