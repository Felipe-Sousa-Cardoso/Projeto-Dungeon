using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsoArma : MonoBehaviour
{
    public CadaArma Valores;
    protected float Cadencia;
    protected float Alcance;
    protected int Velocidade;
    protected float Precisão;
    protected int Pente;
    protected float Recarga;
    protected float Dano;
    protected float ModDanoQualidade;
    protected int MuniçõesPorDisparo;

    public void Qualidade()
    {
        switch (Valores.QualidadeDeManufatura)
        {
            case 0: ModDanoQualidade = 1; break; 
            case 1: ModDanoQualidade = 1.5f; Valores.Modificações.Capacity = 1;  break; 
            case 2: ModDanoQualidade = 2; Valores.Modificações.Capacity = 2; break; 
            case 3: ModDanoQualidade = 3; Valores.Modificações.Capacity = 3; break;
        }
        print(Valores.Modificações.Count);
    }
    public virtual void atirar(GameObject Tiro,Transform Arma)
    {
        for (int i = 0; i < MuniçõesPorDisparo; i++)
        {
            float anguloArma = Arma.eulerAngles.z; //Olha o angulo da arma
            float anguloFinal = anguloArma + Random.Range(-Precisão, Precisão); // Adiciona o valor da precisão de cada arma
            float anguloEmRadianos = anguloFinal * Mathf.Deg2Rad; // Converte o ângulo final em radianos
            Vector2 direcaoTiro = new Vector2(Mathf.Cos(anguloEmRadianos), Mathf.Sin(anguloEmRadianos)); // Calcula a direção do tiro

            GameObject tiro = Instantiate(Tiro, Arma.position, Quaternion.identity);

            tiro.transform.Rotate(new Vector3(0, 0, anguloFinal)); //Corrige a direção do sprite do tiro

            tiro.GetComponent<Rigidbody2D>().velocity = direcaoTiro * Velocidade; // Aplica a direção ao projétil

            Destroy(tiro, Alcance / Velocidade); //Usa valocidade para determinar o alcance
        }
    }
    public virtual void UpdateArma(JogadorArma jog) { }
}
