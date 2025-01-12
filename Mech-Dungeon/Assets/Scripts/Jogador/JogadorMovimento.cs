using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorMovimento : MonoBehaviour
{
    [SerializeField] UsoDash DashAtual;
    Vector3 MousePos;
    [SerializeField] bool isdashing;
    [SerializeField] Vector3 dire��o;

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
        if (!isdashing)
        {
            dire��o = new Vector3(ControladorDeInput.GetMoveInput().x, ControladorDeInput.GetMoveInput().y);
        }
        rb.velocity = dire��o*Time.deltaTime * VelocidadeDeMovimento;  
 
    }
    private void Update()
    {
        GetMousePos(); //Pega a posi��o do mouse em referencia a posi��o atual
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
    #region M�todos de acesso
    public float VelLMov
    {
        get { return VelocidadeDeMovimento; }
        set { VelocidadeDeMovimento=value; }
    }
    public UsoDash GetSetDash
    {
        get { return DashAtual; }
        set { DashAtual = value; }
    }
    public bool Isdashing
    {
        get { return isdashing; }
        set { isdashing = value; }
    }
    #endregion

}
