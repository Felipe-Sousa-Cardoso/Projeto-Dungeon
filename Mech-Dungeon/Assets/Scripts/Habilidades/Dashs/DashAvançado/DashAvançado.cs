using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAvançado : UsoDash
{   private void Start()
    {
        potencia = 6;
        duração = 0.1f;

        switch (Valores.QualidadeDeManufatura)
        {
            case 1: potencia += 2; break;
            case 2: Valores.CD -= 1; break;
        }
        switch (Valores.AtributoEspecial)
        {
            case 1: Valores.CD -=2; break;
            case 2: potencia += 1; break;
            case 3: Valores.Cargas += 1; break;
        }
    }
}
