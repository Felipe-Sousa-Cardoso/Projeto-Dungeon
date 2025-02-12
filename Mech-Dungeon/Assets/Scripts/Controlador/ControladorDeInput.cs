using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorDeInput : MonoBehaviour
{
    // Variáveis de armazenam o valor de cada input
    Vector2 MovementInput;
    [SerializeField] bool dash;
    bool HabilidadeE;
    bool HabilidadeQ;
    bool Tiro;
#region VerificaçãoDeUnicidade
    //Verifica se exite apenas uma intancia do controlador de Input
    public static ControladorDeInput instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
#region Inputs
    //Cria cada input e seu respectivo método de acesso
    public void OnMove(InputValue valor){
        MovementInput = valor.Get<Vector2>();
    }
    public static Vector2 GetMoveInput()
    {
        return instance.MovementInput;
    }
    public void OnDash(InputValue valor){
        dash = valor.isPressed;
    }
    public static bool GetDashInput() 
    {
        return instance.dash;
    }
    public void OnHabilidadeE(InputValue valor)
    {
        HabilidadeE = valor.isPressed;
    }
    public static bool GetHabilidadeEInput()
    {
        return instance.HabilidadeE;
    }
    public void OnHabilidadeQ(InputValue valor)
    {
        HabilidadeQ = valor.isPressed;
    }
    public static bool GetHabilidadeQInput()
    {
        return instance.HabilidadeQ;
    }
    public void OnTiro(InputValue valor)
    {
        Tiro = valor.isPressed;
    }
    public static bool GetTiroInput()
    {
        return instance.Tiro;
    }


    #endregion
#region Correção
    //Reseta o valor dos inputs no final da cada frame, para garantir que possam sem usados novamente
    private void LateUpdate()
    {
        dash = false;
        HabilidadeE = false;
        HabilidadeQ = false;
        
        
    }
#endregion
}