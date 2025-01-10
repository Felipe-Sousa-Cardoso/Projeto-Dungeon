using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(ControladorDeInput.GetMoveInput().x,ControladorDeInput.GetMoveInput().y)*10*Time.fixedDeltaTime;
    }
}
