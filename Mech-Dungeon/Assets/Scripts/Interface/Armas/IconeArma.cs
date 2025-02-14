using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconeArma : MonoBehaviour
{
    [SerializeField] Image arma;
    [SerializeField] Image cobertura;
    Sprite armaAnterior;
    float x; //Usado para controlar o FillAmont da cobertura
    bool coberturaA; //Verifica quando a cobertura dve ser alterada
    [SerializeField] DadosDaArma daArma;
    
    
    void Update()
    {
        if (daArma.sprite!=armaAnterior)
        {
            arma.sprite = armaAnterior = daArma.sprite;
        }

        if (daArma.MuniçãoAtual == 0&&coberturaA)
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
            cobertura.color = new Vector4(0.5f, 0.5f, 0.5f, 0);
            coberturaA = true;
        }
    }


}
