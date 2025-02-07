using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashRapido : UsoDash
{ 
    public override void updateDash(JogadorMovimento jog)
    {
        #region Potencia
        potencia = 2;
        duração = 0.2f;

        if (Valores.AtributoEspecial == 2)
        {
            potencia = 3;
        }
        #endregion
        #region CD e Cargas
        float nCD = 0;
        int nCargas = 0;

        if (Valores.QualidadeDeManufatura >= 1) //Checa a qualidade e altera os valores
        {
            nCargas = 2;
            if (Valores.AtributoEspecial == 3)
            {
                nCargas = 3;
            }


        }
        if (Valores.QualidadeDeManufatura >= 2)
        {
            nCD = -1;
            if (Valores.AtributoEspecial == 1)
            {
                nCD = -2;
            }
        }

        jog.GetSetDashAtual.CDdoDash = jog.GetSetDash.Valores.CD + nCD;
        jog.GetSetDashAtual.CargasDoDash = jog.GetSetDash.Valores.Cargas + nCargas;

        #endregion
    }
}
