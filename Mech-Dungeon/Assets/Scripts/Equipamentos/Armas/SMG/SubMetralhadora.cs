using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMetralhadora : UsoArma
{
    public override void UpdateArma(JogadorArma jog)
    {
        switch (Valores.Cadencia)
        {
            case 1: jog.Cadencia = 6; break;
            case 2: jog.Cadencia = 7; break;
            case 3: jog.Cadencia = 8; break;
        }
        Alcance = 5;
        Velocidade = 15;
        switch (Valores.Precis�o)
        {
            case 1: Precis�o = 20; break;
            case 2: Precis�o = 25; break;
            case 3: Precis�o = 30; break;
        }
        switch (Valores.Pente)
        {
            case 1: jog.Maxmuni��es = 15; break;
            case 2: jog.Maxmuni��es = 20; break;
            case 3: jog.Maxmuni��es = 30; break;
        }
        switch (Valores.Recarga)
        {
            case 1: jog.Recarga = 1; break;
            case 2: jog.Recarga = 1.5f; break;
            case 3: jog.Recarga = 1.5f; break;
        }
        float x = 0;
        switch (Valores.Dano)
        {
            case 1: x = 0.3f; break;
            case 2: x = 0.4f; break;
            case 3: x = 0.5f; break;
        }
        Dano = x * ModDanoQualidade * jog.ModificarDano;
        switch (Valores.Muni��esPorDisparo)
        {
            case 1: Muni��esPorDisparo = 1; break;
            case 2: Muni��esPorDisparo = 1; break;
            case 3: Muni��esPorDisparo = 2; break;
        }
        
    }
}
