using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorArma : MonoBehaviour
{
    [SerializeField] UsoArma armaAtual; //Objeto que contem o Script da arma atualmente equipada
    [SerializeField] GameObject tiro; //Prefab da Muni��o
    [SerializeField] Transform Arma; //Trasform da arma, local onde � pra ser instanciado o tiro
    bool atirando;

    [SerializeField] int muni��es;
    int maxmuni��es;
    float recarga;
    float cadencia;
    bool recarregando;

    float modificarDano; //Modificador global de Dano
    #region M�todos de Acesso
    public UsoArma ArmaAtual
    {
        get { return armaAtual; }
        set { armaAtual = value; }
    }
    public float ModificarDano
    {
        get { return modificarDano;}
        set { modificarDano = value;}
    }
    public int Maxmuni��es
    {
        get { return maxmuni��es; }
        set { maxmuni��es = value; }
    }
    public float Recarga
    {
        get {return recarga;} 
        set { recarga = value; }
    }
    public float Cadencia
    {
        get { return cadencia;}
        set { cadencia = value; }
    }
    #endregion

    private void Start()
    {
        modificarDano = 1;
        
    }
    private void Update()
    {
        UpdateArma();
        if (ControladorDeInput.GetTiroInput() && !atirando && muni��es>0)
        {
            StartCoroutine(CadaTiro(cadencia));
            muni��es--;
        }
        if (muni��es==0&&!recarregando)
        {
            StartCoroutine(Recaregar(Recarga));
        }
        

    }
    public void UpdateArma()
    {
        armaAtual.UpdateArma(this);
    }
    IEnumerator CadaTiro(float t)
    {
        atirando = true;
        armaAtual.atirar(tiro, Arma);
        yield return new WaitForSeconds(1/t);
        atirando = false;
    }
    IEnumerator Recaregar(float t)
    {        
        recarregando = true;
        yield return new WaitForSeconds(t);
        muni��es = maxmuni��es;
        recarregando = false;      
    }
}
