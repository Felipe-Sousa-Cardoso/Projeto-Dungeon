using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorArma : MonoBehaviour
{
    [SerializeField] UsoArma armaAtual; //Objeto que contem o Script da arma atualmente equipada
    [SerializeField] GameObject tiro; //Prefab da Munição
    [SerializeField] Transform Arma; //Trasform da arma, local onde é pra ser instanciado o tiro
    bool atirando;
    int munições;
    bool recarregando;
    #region Métodos de Acesso
    public UsoArma ArmaAtual
    {
        get { return armaAtual; }
        set { armaAtual = value; }
    }
    #endregion

    private void Start()
    {
        munições = armaAtual.Valores.Pente;
    }
    private void Update()
    {
        
        if (ControladorDeInput.GetTiroInput() && !atirando && munições>0)
        {
            StartCoroutine(CadaTiro(armaAtual.Valores.Cadencia));
            munições--;
        }
        if (munições==0&&!recarregando)
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
        munições = armaAtual.Valores.Pente;
        recarregando = false;
       
    }


}
