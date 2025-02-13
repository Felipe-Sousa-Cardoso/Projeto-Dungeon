using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaçãoDoDash : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        spriteRenderer.sprite = GetComponentInParent<JogadorMovimento>().GetSetDash.Valores.sprite;
    }
}
