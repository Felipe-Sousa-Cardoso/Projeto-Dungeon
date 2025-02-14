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
        switch (Valores.Precisão)
        {
            case 1: Precisão = 45; break;
            case 2: Precisão = 60; break;
            case 3: Precisão = 75; break;
        }
        switch (Valores.Pente)
        {
            case 1: jog.Maxmunições = 4; break;
            case 2: jog.Maxmunições = 5; break;
            case 3: jog.Maxmunições = 6; break;
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
        switch (Valores.MuniçõesPorDisparo)
        {
            case 1: MuniçõesPorDisparo = 6; break;
            case 2: MuniçõesPorDisparo = 7; break;
            case 3: MuniçõesPorDisparo = 8; break;
        }
        
    }
}
