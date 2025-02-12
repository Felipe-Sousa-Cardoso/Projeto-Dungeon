using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorArma : MonoBehaviour
{
    [SerializeField] UsoArma armaAtual; //Objeto que contem o Script da arma atualmente equipada
    [SerializeField] GameObject tiro; //Prefab da Muni��o
    [SerializeField] Transform Arma;
    #region M�todos de Acesso
    public UsoArma ArmaAtual
    {
        get { return armaAtual; }
        set { armaAtual = value; }
    }
    #endregion

    private void Update()
    {
        if (ControladorDeInput.GetTiroInput())
        {
            StartCoroutine(armaAtual.atirar(tiro,Arma));
        }
    }

}
