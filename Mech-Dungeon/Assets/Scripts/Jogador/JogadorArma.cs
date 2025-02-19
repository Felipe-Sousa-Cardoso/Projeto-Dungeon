using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorArma : MonoBehaviour
{
    [SerializeField] UsoArma[] armaAtual; //Objeto que contem o conjunto dos Scripts das armas atualmente equipadas
    [SerializeField] DadosDaArma interfaceArmas; //ObejtoScriptavel que faz a comunicação com a interface
    int armaCount = 0; //controla qual arma está equipada
    [SerializeField] GameObject tiro; //Prefab da Munição
    [SerializeField] Transform Arma; //Trasform da arma, local onde é pra ser instanciado o tiro
    bool atirando;

    Coroutine rotinaRecarga;


    int maxmunições;
    float recarga;
    float cadencia;
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
        interfaceArmas.recarregando = false;
        modificarDano = 1;
        UpdateArma();
    }
    private void Update()      
    {
        if (ControladorDeInput.GetTiroInput() && !atirando && armaAtual[armaCount].Valores.muniçãoAtual >0)
        {
            StartCoroutine(CadaTiro(cadencia));
            armaAtual[armaCount].Valores.muniçãoAtual--;
            interfaceArmas.MuniçãoAtual--;
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
            if (rotinaRecarga != null)
            {
                StopCoroutine(rotinaRecarga);
            }

            interfaceArmas.recarregando = false;
        }

        if (armaAtual[armaCount].Valores.muniçãoAtual ==0&&!interfaceArmas.recarregando)
        {
            rotinaRecarga = StartCoroutine(Recaregarold(recarga));
        }
    }
    public void UpdateArma()
    {
        armaAtual[armaCount].Qualidade();
        armaAtual[armaCount].UpdateArma(this);
        interfaceArmas.sprite = armaAtual[armaCount].Valores.sprite;
        if (armaAtual.Length > 1)
        {
            if (armaCount < ArmaAtual.Length - 1)
            {
                interfaceArmas.proxmoSprite = armaAtual[armaCount + 1].Valores.sprite;
            }
            else
            {
                interfaceArmas.proxmoSprite = armaAtual[0].Valores.sprite;
            }
            
        }
        
        interfaceArmas.MuniçãoAtual = armaAtual[armaCount].Valores.muniçãoAtual;
        interfaceArmas.CDrecarga = recarga;
        Arma.GetComponent<AnimaçãoArma>().AlterarArma(armaAtual[armaCount].Valores.sprite);
    }
    IEnumerator CadaTiro(float t)
    {
        atirando = true;
        armaAtual[armaCount].atirar(tiro, Arma);
        yield return new WaitForSeconds(1/t);
        atirando = false;
    }
    IEnumerator Recaregarold(float t)
    {
        interfaceArmas.recarregando = true;
        yield return new WaitForSeconds(t);
        armaAtual[armaCount].Valores.muniçãoAtual = interfaceArmas.MuniçãoAtual = maxmunições;
        interfaceArmas.recarregando = false;
    }
    IEnumerator TrocaDeArma()
    {
        trocaDeArmaCD = true;
        yield return new WaitForSeconds(1); 
        trocaDeArmaCD = false;
    }
}
