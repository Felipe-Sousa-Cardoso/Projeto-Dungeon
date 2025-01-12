using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAvançado : UsoDash
{
    public override IEnumerator usodash(JogadorMovimento jog)
    {
        jog.Isdashing = true;
        jog.VelLMov *= 6;
        yield return new WaitForSeconds(0.1f);
        jog.VelLMov /= 6;
        jog.Isdashing = false;
    }
}
