using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconeDoDash : MonoBehaviour
{
    [SerializeField] DadosDoDash DadosDash;
    [SerializeField] Image Cobertura; //Cobertura do icone do dash
    [SerializeField] Image[] IconesDeCarga;
    int CargasAnteriores;
    bool animaçãoDash;

    private void Update()
    {
        TrasparenciaDacobertura();
        QuantidadeDeCargas();
    }
    void TrasparenciaDacobertura()
    {
        if (DadosDash.CargasDoDash==0)
        {
            Cobertura.fillAmount = DadosDash.ContadorCDdash / DadosDash.CDdoDash;          
            Cobertura.color = new Vector4(0.5f, 0.5f, 0.5f, 0.6f);
            animaçãoDash = false;
        }
        if(DadosDash.CargasDoDash != 0 && !animaçãoDash)
        {
            animaçãoDash = true;
            Cobertura.color = new Vector4(0.5f, 0.5f, 0.5f, 0);
        }
        
    } //Altera a transparencia da cobertura baseado na quantidade de cargas e temporizador de
    void QuantidadeDeCargas()
    {
        if (DadosDash.CargasDoDash != CargasAnteriores)
        {
            for (int i = 0; i < IconesDeCarga.Length; i++)
            {
                if (i <= DadosDash.CargasDoDash - 1)
                {
                    IconesDeCarga[i].gameObject.SetActive(true);
                }
                else
                {
                    IconesDeCarga[i].gameObject.SetActive(false);
                }
            }
            CargasAnteriores = DadosDash.CargasDoDash;
        }      
    }
}
