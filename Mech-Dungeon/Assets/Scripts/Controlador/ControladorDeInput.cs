using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorDeInput : MonoBehaviour
{

    Vector2 MovementInput;
    bool dash;
#region VerificaçãoDeUnicidade
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

    #endregion
    #region Correção
    private void LateUpdate()
    {
        dash = false;
    }
#endregion
}