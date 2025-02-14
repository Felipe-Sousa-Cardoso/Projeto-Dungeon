using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escopeta : UsoArma
{
    public override void UpdateArma(JogadorArma jog)
    {
        jog.Cadencia = 1;
        Alcance = 3;
        Velocidade = 6;
        switch (Valores.Precis�o)
        {
            case 1: Precis�o = 45; break;
            case 2: Precis�o = 60; break;
            case 3: Precis�o = 75; break;
        }
        switch (Valores.Pente)
        {
            case 1: jog.Maxmuni��es = 4; break;
            case 2: jog.Maxmuni��es = 5; break;
            case 3: jog.Maxmuni��es = 6; break;
        }
        switch (Valores.Recarga)
        {
            case 1: jog.Recarga = 1.5f; break;
            case 2: jog.Recarga = 1.5f; break;
            case 3: jog.Recarga = 2; break;
        }
        float x = 0;
        switch (Valores.Dano)
        {
            case 1: x = 0.6f; break; 
            case 2: x = 0.8f; break;
            case 3: x = 1f; break;
        }
        Dano = x * ModDanoQualidade * jog.ModificarDano;
        switch (Valores.Muni��esPorDisparo)
        {
            case 1: Muni��esPorDisparo = 6; break;
            case 2: Muni��esPorDisparo = 7; break;
            case 3: Muni��esPorDisparo = 8; break;
        }
        
    }
}
