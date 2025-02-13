using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Switch;

public class Pistola : UsoArma
{

    public override void UpdateArma(JogadorArma jog)
    {
        switch (Valores.Cadencia)
        {
            case 1: jog.Cadencia = 2; break; 
            case 2: jog.Cadencia = 3; break;
            case 3: jog.Cadencia = 4; break; 
        }
        switch(Valores.Alcance)
        {
            case 1: Alcance = 6; break;
            case 2: Alcance = 8; break;
            case 3: Alcance = 12; break;
        }
        Velocidade = 10;
        switch(Valores.Precis�o)
        {
            case 1: Precis�o = 10; break;
            case 2: Precis�o = 15; break;
            case 3: Precis�o = 20; break;
        }
        switch (Valores.Pente)
        {
            case 1: jog.Maxmuni��es = 8; break;
            case 2: jog.Maxmuni��es = 10; break;
            case 3: jog.Maxmuni��es = 12; break;
        }
        switch (Valores.Recarga)
        {
            case 1: jog.Recarga = 1; break;
            case 2: jog.Recarga = 1.5f; break;
            case 3: jog.Recarga = 2; break;
        }
        Dano = 1 * ModDanoQualidade * jog.ModificarDano;
        Muni��esPorDisparo = 1;      
    }

}

