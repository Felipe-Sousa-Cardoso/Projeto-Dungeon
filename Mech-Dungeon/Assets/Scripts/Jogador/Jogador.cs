using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jogador : MonoBehaviour
{
    [SerializeField] UsoDash DashAtual;
    Vector3 MousePos;
    [SerializeField] bool isdashing;

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
        
        rb.velocity = new Vector3(ControladorDeInput.GetMoveInput().x, ControladorDeInput.GetMoveInput().y) * Time.deltaTime * VelocidadeDeMovimento;  //Movimentação
       
        

    }
    private void Update()
    {
        GetMousePos(); //Pega a posição do mouse em referencia a posção do mouse
        if (ControladorDeInput.GetDashInput())
        {
            
            StartCoroutine(DashAtual.usodash(this));
            
        }


    }

    void GetMousePos()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        transform.right = new Vector2(MousePos.x - transform.position.x, MousePos.y - transform.position.y);
    }
    #region Métodos de acesso
    public float VelLMov
    {
        get { return VelocidadeDeMovimento; }
        set { VelocidadeDeMovimento=value; }
    }
    public bool Isdashing
    {
        get { return isdashing; }
        set { isdashing = value; }
    }
    #endregion

}
