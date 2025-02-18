using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconeArma : MonoBehaviour
{
    [SerializeField] Image arma;
    [SerializeField] Image proxArma;
    [SerializeField] RectTransform muni��es;
    [SerializeField] Image cobertura;
    Sprite armaAnterior;
    float x; //Usado para controlar o FillAmont da cobertura
    [SerializeField] DadosDaArma daArma;
    int muni��oAnterior;
    bool executando;
    
    
    void Update()
    {
        if (daArma.sprite!=armaAnterior) //Verifica se o sprite da arma � diferente e faz a troca
        {
            arma.sprite = armaAnterior = daArma.sprite;
            proxArma.sprite = daArma.proxmoSprite;
            x = 0;
        }

        if (daArma.recarregando) 
        {         
            if(x == 0) //altera a cor da cobertura apenas uma vez antes de come�ar a crescelo com o tome.deltatime
            {
                cobertura.color = new Vector4(0.5f, 0.5f, 0.5f, 0.6f); 
                executando = false;
            }        
            x += Time.deltaTime;
            cobertura.fillAmount = x / daArma.CDrecarga;
           
        }
        if (!daArma.recarregando && !executando) //Apaga a cobertura cinza quando a arma n�o est� recerregando
        {
            cobertura.color = new Vector4(0.5f, 0.5f, 0.5f, 0);
            x = 0;
            executando = true;
        }

        if ((muni��oAnterior != daArma.Muni��oAtual) || daArma.Muni��oAtual==0) //Altera o tamanho da imagem, por ela ser tipo tiled ela se replica em vz de esticar
        {
            muni��oAnterior = daArma.Muni��oAtual;
            muni��es.sizeDelta = new Vector2 (13, muni��oAnterior*8);
            muni��es.anchoredPosition = new Vector2 (920, -375+muni��oAnterior*12);
        }
    }
}
