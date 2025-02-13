using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorArma : MonoBehaviour
{
    [SerializeField] UsoArma armaAtual; //Objeto que contem o Script da arma atualmente equipada
    [SerializeField] GameObject tiro; //Prefab da Muni��o
    [SerializeField] Transform Arma; //Trasform da arma, local onde � pra ser instanciado o tiro
    bool atirando;
    int muni��es;
    bool recarregando;
    #region M�todos de Acesso
    public UsoArma ArmaAtual
    {
        get { return armaAtual; }
        set { armaAtual = value; }
    }
    #endregion

    private void Start()
    {
        muni��es = armaAtual.Valores.Pente;
    }
    private void Update()
    {
        
        if (ControladorDeInput.GetTiroInput() && !atirando && muni��es>0)
        {
            StartCoroutine(CadaTiro(armaAtual.Valores.Cadencia));
            muni��es--;
        }
        if (muni��es==0&&!recarregando)
        {
            StartCoroutine(Recarga(armaAtual.Valores.Recarga));
        }
        

    }
    IEnumerator CadaTiro(float t)
    {
        atirando = true;
        armaAtual.atirar(tiro, Arma);
        yield return new WaitForSeconds(1/t);
        atirando = false;
    }
    IEnumerator Recarga(float t)
    {        
        recarregando = true;
        print("s");
        yield return new WaitForSeconds(t);
        muni��es = armaAtual.Valores.Pente;
        recarregando = false;
       
    }


}
