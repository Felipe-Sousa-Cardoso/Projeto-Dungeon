using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaçãoArma : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    JogadorArma jog;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        jog = GetComponentInParent<JogadorArma>();
    }
    void FixedUpdate()
    {
        spriteRenderer.sprite = jog.ArmaAtual[jog.ArmaCount].Valores.sprite;
    }
}
