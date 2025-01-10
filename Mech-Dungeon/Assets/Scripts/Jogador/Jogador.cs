using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jogador : MonoBehaviour
{
    Vector3 MousePos;
    float VelocidadeDeMovimento = 200;

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(ControladorDeInput.GetMoveInput().x,ControladorDeInput.GetMoveInput().y)*Time.deltaTime*VelocidadeDeMovimento;  //Movimenta��o

    }
    private void Update()
    {
        GetMousePos(); //Pega a posi��o do mouse em referencia a pos��o do mouse
        if (ControladorDeInput.GetDashInput())
        {
            print("Dash");
            VelocidadeDeMovimento *=3;
        }


    }

    void GetMousePos()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        transform.right = new Vector2(MousePos.x - transform.position.x, MousePos.y - transform.position.y);
    }
}
