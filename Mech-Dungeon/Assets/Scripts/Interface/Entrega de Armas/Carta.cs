using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carta : MonoBehaviour
{
    
    [SerializeField] Image Icone;
    [SerializeField] Image CartaToda;
    ParticleSystem particle;
    [SerializeField] Image borda;
    [SerializeField] Sprite[] bordas;
    [SerializeField] Text Nome;
    [SerializeField] Text Descrição;

    public JogadorMovimento jog;
    public UsoDash dah;
    public CadaCarta carta;
    public int qualidade;
    public int atributo;



    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
        CartaToda = GetComponent<Image>();
        Icone.sprite = carta.sprite;
        switch (qualidade)
        {
            case 0: borda.color = new Vector4(1,1,1,0); break; 
            case 1: borda.sprite = bordas[0]; break; 
            case 2: borda.sprite = bordas[1]; break;
        }
        ParticleSystem.MainModule main = particle.main;
        switch (atributo)
        {        
            case 0: particle.Pause(); break;
            case 1: main.startColor = Color.blue; CartaToda.color = new Color(0.722f, 1, 0.973f); break;
            case 2: main.startColor  = Color.red; CartaToda.color = new Color(1, 0.514f, 0.514f); break;
            case 3: main.startColor = Color.yellow; CartaToda.color = new Color(0.984f, 1, 0.514f); break; 
        }

        Nome.text = carta.Nome;
        Descrição.text = carta.Descricao;
    }
    
    public void DarODash()
    {
        jog.GetSetDash = dah;
        dah.Valores.QualidadeDeManufatura = qualidade;
        dah.Valores.AtributoEspecial = atributo;
        jog.UpdateDash();
        GerenciadorDeCartas.instancia.Destruir();
    }
}
