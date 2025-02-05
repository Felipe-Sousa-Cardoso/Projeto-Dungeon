using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorMovimento : MonoBehaviour
{
    [SerializeField] UsoDash DashAtual; //� o objeto que contem o script do Dash
    [SerializeField] DadosDoDash DadosDash; //Armazena os valores do Dash, � usado para controle de cargas e interface, � um objeto Scriptavel
    Vector3 MousePos;
    [SerializeField] bool isdashing; 
    [SerializeField] Vector3 dire��o;
    [SerializeField] // Usado para ser decressido para fazer o controle de coll down do Dash
    float VelocidadeDeMovimento = 200;

    TrailRenderer TrailRenderer;

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
        TrailRenderer = rb.GetComponent<TrailRenderer>();
    }
    void Start()
    {       
        UpdateDash();
        DadosDash.ContadorCDdash = DadosDash.CDdoDash;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TrailRenderer.emitting = isdashing; //Controla a emiss�o do rastro baseado se o personagem est� fazendo o dash
        if (!isdashing)
        {
            dire��o = new Vector3(ControladorDeInput.GetMoveInput().x, ControladorDeInput.GetMoveInput().y);
        }
        rb.velocity = dire��o*Time.deltaTime * VelocidadeDeMovimento;  
 
    }
    private void Update()
    { 
        //Todos os inputs e seus efeitos
        #region Input
        if (ControladorDeInput.GetDashInput())
        {  
            if (DadosDash.CargasDoDash>=1)
            {
                StartCoroutine(DashAtual.usodash(this));     
                DadosDash.CargasDoDash --;
            }               
        }
        #endregion
        ControleCDDash();
        GetMousePos();
        if (Input.GetKeyDown(KeyCode.G))
        {
            UpdateDash();
        }

    }
    void ControleCDDash() //Faz as verifica��es do Cd e da quantidade de cargas
    {
        if (DadosDash.CargasDoDash < DashAtual.Valores.Cargas)
        {
            DadosDash.ContadorCDdash -= Time.deltaTime;
        }
        if (DadosDash.ContadorCDdash <= 0)
        {
            DadosDash.ContadorCDdash = DadosDash.CDdoDash;
            DadosDash.CargasDoDash++;
        }

        
    }
    void UpdateDash() //Tr�s os valores do script de cada dash para o objeto scriptavel
    {
        DadosDash.CDdoDash = DashAtual.Valores.CD;
        DadosDash.CargasDoDash = DashAtual.Valores.Cargas;
    }
    void GetMousePos()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        transform.right = new Vector2(MousePos.x - transform.position.x, MousePos.y - transform.position.y);
    } //Pega a posi��o do mouse em referencia a posi��o atual
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
