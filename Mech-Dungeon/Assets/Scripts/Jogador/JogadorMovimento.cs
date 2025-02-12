using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorMovimento : MonoBehaviour
{
    [SerializeField] UsoDash DashAtual; //É o objeto que contem o script do Dash
    [SerializeField] DadosDoDash DadosDash; //Armazena os valores do Dash, é usado para controle de cargas e interface, é um objeto Scriptavel
    Vector3 MousePos;
    bool isdashing; 
    Vector3 direção;
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
        ResetDash();
        DadosDash.ContadorCDdash = DadosDash.CDdoDash;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TrailRenderer.emitting = isdashing; //Controla a emissão do rastro baseado se o personagem está fazendo o dash
        if (!isdashing)
        {
            direção = new Vector3(ControladorDeInput.GetMoveInput().x, ControladorDeInput.GetMoveInput().y);
        }
        rb.velocity = direção*Time.deltaTime * VelocidadeDeMovimento;  
 
    }
    private void Update()
    { 
        //Todos os inputs e seus efeitos
        #region Input
        if (ControladorDeInput.GetDashInput())
        {  
            if (DadosDash.CargasDoDash>=1&&rb.velocity!= new Vector2(0,0))
            {
                StartCoroutine(DashAtual.usodash(this));     
                DadosDash.CargasDoDash --;
            }               
        }
        #endregion
        ControleCDDash();
        GetMousePos();
    }
    void ControleCDDash() //Faz as verificações do Cd e da quantidade de cargas
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
    private void ResetDash() //Trás o Dash para a configuração inicial
    {
        DashAtual = Resources.Load<UsoDash>("Dashs/DashBasico");
        DashAtual.Valores.QualidadeDeManufatura = 0;
        DashAtual.Valores.AtributoEspecial = 0;
        UpdateDash();
    }
    public void UpdateDash() //Trás os valores do script de cada dash para o objeto scriptavel
    {
        DashAtual.updateDash(this); 
        
    }
    void GetMousePos()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        transform.right = new Vector2(MousePos.x - transform.position.x, MousePos.y - transform.position.y);
    } //Pega a posição do mouse em referencia a posição atual
    #region Métodos de acesso
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
    public DadosDoDash GetSetDashAtual
    {
        get { return DadosDash; }
        set { DadosDash = value; }
    }
    public bool Isdashing
    {
        get { return isdashing; }
        set { isdashing = value; }
    }
    #endregion

}
