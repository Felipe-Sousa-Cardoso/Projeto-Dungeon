using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorArma : MonoBehaviour
{
    [SerializeField] UsoArma armaAtual; //Objeto que contem o Script da arma atualmente equipada
    [SerializeField] GameObject tiro; //Prefab da Munição
    [SerializeField] Transform Arma;
    #region Métodos de Acesso
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
