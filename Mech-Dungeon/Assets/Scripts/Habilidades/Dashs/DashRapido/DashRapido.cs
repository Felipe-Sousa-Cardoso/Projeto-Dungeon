using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashRapido : UsoDash
{   private void Start()
    {
        potencia = 2;
        duração = 0.2f;
        switch (Valores.QualidadeDeManufatura)
        {
            case 1: break;
            case 2: break;
        }
        switch (Valores.AtributoEspecial)
        {
            case 2: potencia +=1; break;
        }
    }
}
