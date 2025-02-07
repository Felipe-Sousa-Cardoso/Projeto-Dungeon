using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAvançado : UsoDash
{
    public override void updateDash(JogadorMovimento jog)
    {
        #region Potencia
        potencia = 6;
        duração = 0.1f;

        if (Valores.QualidadeDeManufatura >= 1)
        {
            potencia = 8;
        }
        if (Valores.AtributoEspecial == 2)
        {
            potencia = 7;
            if(Valores.QualidadeDeManufatura >= 1)
            {
                potencia = 9;
            }
        }
        #endregion
        #region CD e Cargas
        float nCD = 0;
        int nCargas = 0;

        if (Valores.QualidadeDeManufatura >= 2) //Checa a qualidade e altera os valores
        {
            nCD = -1;
        }
        switch (Valores.AtributoEspecial) //Checa o atributo especial e verifica se a qualidade existe
        {
            case 1:
                if (Valores.QualidadeDeManufatura>=2)
                {
                    nCD = -3;
                }
                else
                {
                    nCD= -2;
                }
            break;
            case 3: nCargas = 1; break;
        }

        jog.GetSetDashAtual.CDdoDash = jog.GetSetDash.Valores.CD + nCD;
        jog.GetSetDashAtual.CargasDoDash = jog.GetSetDash.Valores.Cargas + nCargas;
    }
    #endregion
}
