using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsoArma : MonoBehaviour
{
    public CadaArma Valores;
    
    public virtual IEnumerator atirar(GameObject Tiro,Transform Arma)
    {
        GameObject tiro;
        tiro = Instantiate(Tiro,Arma.position,Arma.rotation);
        tiro.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(300,0));
        yield return null;
    }
}
