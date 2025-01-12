using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UsoDash : MonoBehaviour
{
    public CadaDash Valores;
    public abstract IEnumerator usodash(JogadorMovimento jog);
}
