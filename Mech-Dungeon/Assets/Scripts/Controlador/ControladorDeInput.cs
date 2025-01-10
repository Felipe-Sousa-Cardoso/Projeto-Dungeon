using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorDeInput : MonoBehaviour
{

    public Vector2 MovementInput;
    public bool dash;
#region VerificaçãoDeUnicidade
    public static ControladorDeInput instance;
    void Awake(){
    if (instance == null){
        instance = this;
    }
    else {
    Destroy(gameObject);
    }
    }
    #endregion
#region Inputs


    public void OnMove(InputValue valor){
        MovementInput = valor.Get<Vector2>();
    }
    public void OnDash(InputValue valor){
        dash = valor.isPressed;
    }
#endregion
#region Correcao
    void LateUpdate(){
        if (dash){
            dash = false ;
        }
        
    }
    
#endregion
}