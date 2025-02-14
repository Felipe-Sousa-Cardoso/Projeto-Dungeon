using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : UsoArma
{
    public override void UpdateArma(JogadorArma jog)
    {
        switch (Valores.Cadencia)
        {
            case 1: jog.Cadencia = 4; break;
            case 2: jog.Cadencia = 4.5f; break;
            case 3: jog.Cadencia = 5; break;
        }
        switch (Valores.Alcance)
        {
            case 1: Alcance = 10; break;
            case 2: Alcance = 12; break;
            case 3: Alcance = 15; break;
        }      
        Velocidade = 20;
        switch (Valores.Precisão)
        {
            case 1: Precisão = 5; break;
            case 2: Precisão = 7; break;
            case 3: Precisão = 10; break;
        }
        switch (Valores.Pente)
        {
            case 1: jog.Maxmunições = 12; break;
            case 2: jog.Maxmunições = 16; break;
            case 3: jog.Maxmunições = 20; break;
        }
        switch (Valores.Recarga)
        {
            case 1: jog.Recarga = 1; break;
            case 2: jog.Recarga = 2f; break;
            case 3: jog.Recarga = 3f; break;
        }
        float x = 0;
        switch (Valores.Dano)
        {
            case 1: x = 0.8f; break;
            case 2: x = 1; break;
            case 3: x = 1.4f; break;
        }
        Dano = x * ModDanoQualidade * jog.ModificarDano;
        MuniçõesPorDisparo = 1;
    }
}
