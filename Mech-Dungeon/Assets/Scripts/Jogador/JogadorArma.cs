using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorArma : MonoBehaviour
{
    [SerializeField] UsoArma[] armaAtual; //Objeto que contem o conjunto dos Scripts das armas atualmente equipadas
    [SerializeField] int armaCount = 0;
    [SerializeField] GameObject tiro; //Prefab da Munição
    [SerializeField] Transform Arma; //Trasform da arma, local onde é pra ser instanciado o tiro
    bool atirando;

    int maxmunições;
    float recarga;
    float cadencia;
    bool recarregando;
    bool trocaDeArmaCD;

    float modificarDano; //Modificador global de Dano
    #region Métodos de Acesso
    public UsoArma[] ArmaAtual
    {
        get { return armaAtual; }
        set { armaAtual = value; }
    }
    public float ModificarDano
    {
        get { return modificarDano;}
        set { modificarDano = value;}
    }
    public int Maxmunições
    {
        get { return maxmunições; }
        set { maxmunições = value; }
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
    public int ArmaCount
    {
        get { return armaCount; }
        set { armaCount = value; }
    }
    #endregion

    private void Start()
    {
        modificarDano = 1;
        UpdateArma();
    }
    private void Update()      
    {
        if (ControladorDeInput.GetTiroInput() && !atirando && armaAtual[armaCount].Valores.muniçãoAtual >0)
        {
            StartCoroutine(CadaTiro(cadencia));
            armaAtual[armaCount].Valores.muniçãoAtual--;
        }

        if (ControladorDeInput.GetTrocaArmaInput()&&!trocaDeArmaCD)
        {
            StartCoroutine(TrocaDeArma());
            if (armaCount < ArmaAtual.Length-1)
            {
                armaCount++;
            }
            else
            {
                armaCount = 0;
            }
            UpdateArma();
        }

        if (armaAtual[armaCount].Valores.muniçãoAtual ==0&&!recarregando)
        {
            StartCoroutine(Recaregar(Recarga));
        }
    }
    public void UpdateArma()
    {
        armaAtual[armaCount].UpdateArma(this);
    }
    IEnumerator CadaTiro(float t)
    {
        atirando = true;
        armaAtual[armaCount].atirar(tiro, Arma);
        yield return new WaitForSeconds(1/t);
        atirando = false;
    }
    IEnumerator Recaregar(float t)
    {        
        recarregando = true;
        yield return new WaitForSeconds(t);
        armaAtual[armaCount].Valores.muniçãoAtual = maxmunições;
        recarregando = false;      
    }
    IEnumerator TrocaDeArma()
    {
        trocaDeArmaCD = true;
        yield return new WaitForSeconds(3); 
        trocaDeArmaCD = false;
    }
}