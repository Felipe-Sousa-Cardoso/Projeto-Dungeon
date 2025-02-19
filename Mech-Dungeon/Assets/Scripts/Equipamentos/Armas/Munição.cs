using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnDestroy()
    {
        print(dano);
    }
}
