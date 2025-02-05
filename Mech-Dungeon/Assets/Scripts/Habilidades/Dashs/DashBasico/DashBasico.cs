using System.Collections;
using UnityEngine;

public class DashBasico : UsoDash
{
    private void Start()
    {
        potencia = 3;
        duração = 0.2f;
        switch (Valores.QualidadeDeManufatura)
        {
            case 1: break;
            case 2: break;
        }
        switch (Valores.AtributoEspecial)
        {
            case 2: potencia += 2; break;
        }
    }
    
}
