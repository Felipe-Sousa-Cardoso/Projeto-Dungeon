using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconeArma : MonoBehaviour
{
    [SerializeField] Image arma;
    [SerializeField] RectTransform munições;
    [SerializeField] Image cobertura;
    Sprite armaAnterior;
    [SerializeField] float x; //Usado para controlar o FillAmont da cobertura
    [SerializeField] DadosDaArma daArma;
    int muniçãoAnterior;
    [SerializeField] bool executando;
    
    
    void Update()
    {
        if (daArma.sprite!=armaAnterior)
        {
            arma.sprite = armaAnterior = daArma.sprite;
            x = 0;
        }

        if (daArma.recarregando)
        {         
            if(x == 0)
            {
                cobertura.color = new Vector4(0.5f, 0.5f, 0.5f, 0.6f);
                executando = false;
                print("cob");
            }        
            x += Time.deltaTime;
            cobertura.fillAmount = x / daArma.CDrecarga;
           
        }
        if (!daArma.recarregando && !executando)
        {
            cobertura.color = new Vector4(0.5f, 0.5f, 0.5f, 0);
            x = 0;
            print("pronto");
            executando = true;
        }

        if ((muniçãoAnterior != daArma.MuniçãoAtual) || daArma.MuniçãoAtual==0)
        {
            muniçãoAnterior = daArma.MuniçãoAtual;
            munições.sizeDelta = new Vector2 (13, muniçãoAnterior*8);
            munições.anchoredPosition = new Vector2 (920, -375+muniçãoAnterior*12);
        }
    }
}
