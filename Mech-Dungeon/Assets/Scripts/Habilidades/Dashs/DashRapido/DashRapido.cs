using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashRapido : UsoDash
{
    public override IEnumerator usodash(JogadorMovimento jog)
    {
        jog.Isdashing = true;
        jog.VelLMov *= 2;
        yield return new WaitForSeconds(0.2f);
        jog.VelLMov /= 2;
        jog.Isdashing = false;
    }
}
