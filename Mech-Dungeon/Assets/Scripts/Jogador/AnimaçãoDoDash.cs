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
    public void SpriteDash(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
