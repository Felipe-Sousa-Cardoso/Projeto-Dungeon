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
    void Update()
    {
        spriteRenderer.sprite = GetComponentInParent<JogadorArma>().ArmaAtual.Valores.sprite;
    }
}
