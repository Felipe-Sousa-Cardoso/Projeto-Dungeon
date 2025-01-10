using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashbasico : UsoDash
{
    public override IEnumerator usodash(float VelMov)
    {
        print("Começo");
        VelMov = 500;
        yield return new WaitForSeconds(1f);
        VelMov = 200;
        print("Final");
    }
}
