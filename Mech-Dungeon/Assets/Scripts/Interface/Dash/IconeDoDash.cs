using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconeDoDash : MonoBehaviour
{
    [SerializeField] DadosDoDash DadosDash;
    [SerializeField] Image Cobertura; //Cobertura do icone do dash
    [SerializeField] Image[] IconesDeCarga;

    private void Update()
    {
        TrasparenciaDacobertura();
        QuantidadeDeCargas();
    }
    void TrasparenciaDacobertura()
    {
        Cobertura.fillAmount = DadosDash.ContadorCDdash / DadosDash.CDdoDash;
        if (DadosDash.CargasDoDash == 0)
        {
            Cobertura.color = new Vector4(0.5f, 0.5f, 0.5f, 0.6f);
        }
        else
        {
            Cobertura.color = new Vector4(0.5f, 0.5f, 0.5f, 0);
        }
    } //Altera a transparencia da cobertura baseado na quantidade de cargas e temporizador de
    void QuantidadeDeCargas()
    {
        for (int i = 0;i< IconesDeCarga.Length;i++)
        {
            if (i <= DadosDash.CargasDoDash-1)
            {
                IconesDeCarga[i].gameObject.SetActive(true);
            }
            else
            {
                IconesDeCarga[i].gameObject.SetActive(false);   
            }
        }
        
       
    }
}
