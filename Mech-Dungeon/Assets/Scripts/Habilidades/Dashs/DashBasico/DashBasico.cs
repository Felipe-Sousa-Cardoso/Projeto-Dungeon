using System.Collections;
using UnityEngine;

public class DashBasico : UsoDash
{
    public override IEnumerator usodash(JogadorMovimento jog)
    {
        jog.Isdashing = true;
        jog.VelLMov *= 3;
        yield return new WaitForSeconds(0.2f);
        jog.VelLMov /= 3;
        jog.Isdashing = false;
    }
}
