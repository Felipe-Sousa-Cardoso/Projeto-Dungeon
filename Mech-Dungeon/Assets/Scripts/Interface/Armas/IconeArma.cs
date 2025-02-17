using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconeArma : MonoBehaviour
{
    [SerializeField] Image arma;
    [SerializeField] RectTransform muni��es;
    [SerializeField] Image cobertura;
    Sprite armaAnterior;
    [SerializeField] float x; //Usado para controlar o FillAmont da cobertura
    bool coberturaA; //Verifica quando a cobertura dve ser alterada
    [SerializeField] DadosDaArma daArma;
    int muni��oAnterior;
    
    
    void Update()
    {
        if (daArma.sprite!=armaAnterior)
        {
            arma.sprite = armaAnterior = daArma.sprite;
            
        }

        if (daArma.Muni��oAtual == 0 && coberturaA)
        {
            cobertura.color = new Vector4(0.5f, 0.5f, 0.5f, 0.6f);
            x += Time.deltaTime;
            cobertura.fillAmount = x/daArma.CDrecarga;
            if (x >= daArma.CDrecarga)
            {
                x = 0;
                coberturaA = false;
            }
        }
        if (!coberturaA)
        {
            x = 0;
            cobertura.color = new Vector4(0.5f, 0.5f, 0.5f, 0);
            coberturaA = true;
        }

        if ((muni��oAnterior != daArma.Muni��oAtual) || daArma.Muni��oAtual==0)
        {
            muni��oAnterior = daArma.Muni��oAtual;
            muni��es.sizeDelta = new Vector2 (13, muni��oAnterior*8);
            muni��es.anchoredPosition = new Vector2 (920, -375+muni��oAnterior*12);
        }
    }
}
