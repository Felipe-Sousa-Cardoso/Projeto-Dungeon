using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashrápido : UsoDash
{
    public override IEnumerator usodash(Jogador jog)
    {
        jog.Isdashing = true;
        jog.VelLMov *= 6;
        yield return new WaitForSeconds(0.1f);
        jog.VelLMov /= 6;
        jog.Isdashing = false;

    }
}
