using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaçãoDoDash : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = GetComponentInParent<JogadorMovimento>().GetSetDash.Valores.sprite;
    }
}
