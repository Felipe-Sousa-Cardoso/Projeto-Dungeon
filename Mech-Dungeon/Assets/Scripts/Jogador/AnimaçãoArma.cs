using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaçãoArma : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void AlterarArma(Sprite arma)
    {
        spriteRenderer.sprite = arma;
    }
}
