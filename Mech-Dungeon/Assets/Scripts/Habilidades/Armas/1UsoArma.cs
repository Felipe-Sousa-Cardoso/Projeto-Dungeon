using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsoArma : MonoBehaviour
{
    public CadaArma Valores;
    
    public virtual void atirar(GameObject Tiro,Transform Arma)
    {
        for (int i = 0; i < Valores.MuniçõesPorDisparo; i++)
        {
            float anguloArma = Arma.eulerAngles.z; //Olha o angulo da arma
            float anguloFinal = anguloArma + Random.Range(-Valores.Precisão, Valores.Precisão); // Adiciona o valor da precisão de cada arma
            float anguloEmRadianos = anguloFinal * Mathf.Deg2Rad; // Converte o ângulo final em radianos
            Vector2 direcaoTiro = new Vector2(Mathf.Cos(anguloEmRadianos), Mathf.Sin(anguloEmRadianos)); // Calcula a direção do tiro

            GameObject tiro = Instantiate(Tiro, Arma.position, Quaternion.identity);

            tiro.transform.Rotate(new Vector3(0, 0, anguloFinal)); //Corrige a direção do sprite do tiro

            tiro.GetComponent<Rigidbody2D>().velocity = direcaoTiro * Valores.Velocidade; // Aplica a direção ao projétil

            Destroy(tiro, Valores.Alcance / Valores.Velocidade); //Usa valocidade para determinar o alcance
        }
    }
}
