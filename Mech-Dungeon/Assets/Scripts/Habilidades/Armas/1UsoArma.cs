using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsoArma : MonoBehaviour
{
    public CadaArma Valores;
    
    public virtual void atirar(GameObject Tiro,Transform Arma)
    {
        for (int i = 0; i < Valores.Muni��esPorDisparo; i++)
        {
            float anguloArma = Arma.eulerAngles.z; //Olha o angulo da arma
            float anguloFinal = anguloArma + Random.Range(-Valores.Precis�o, Valores.Precis�o); // Adiciona o valor da precis�o de cada arma
            float anguloEmRadianos = anguloFinal * Mathf.Deg2Rad; // Converte o �ngulo final em radianos
            Vector2 direcaoTiro = new Vector2(Mathf.Cos(anguloEmRadianos), Mathf.Sin(anguloEmRadianos)); // Calcula a dire��o do tiro

            GameObject tiro = Instantiate(Tiro, Arma.position, Quaternion.identity);

            tiro.transform.Rotate(new Vector3(0, 0, anguloFinal)); //Corrige a dire��o do sprite do tiro

            tiro.GetComponent<Rigidbody2D>().velocity = direcaoTiro * Valores.Velocidade; // Aplica a dire��o ao proj�til

            Destroy(tiro, Valores.Alcance / Valores.Velocidade); //Usa valocidade para determinar o alcance
        }
    }
}
