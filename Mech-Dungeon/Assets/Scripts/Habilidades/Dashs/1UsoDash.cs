using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsoDash : MonoBehaviour
{
    public CadaDash Valores;
    protected float potencia;
    protected float dura��o;
    public virtual IEnumerator usodash(JogadorMovimento jog)
    {
        jog.Isdashing = true;
        jog.VelLMov *= potencia;
        yield return new WaitForSeconds(dura��o);
        jog.VelLMov /= potencia;
        jog.Isdashing = false;
    }
}
