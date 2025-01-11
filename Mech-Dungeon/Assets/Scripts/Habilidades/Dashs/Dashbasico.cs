using System.Collections;
using UnityEngine;

public class Dashbasico : UsoDash
{
    public override IEnumerator usodash(Jogador jog)
    {
        jog.Isdashing = true;
        jog.VelLMov *= 3;
        yield return new WaitForSeconds(0.2f);
        jog.VelLMov /= 3;
        jog.Isdashing = false;

    }
}
