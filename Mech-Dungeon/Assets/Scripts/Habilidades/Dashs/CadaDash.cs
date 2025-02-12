using UnityEngine;


[CreateAssetMenu(fileName = "cadaDash", menuName = "Hablidades/Dash")]
public class CadaDash : CadaCarta
{
    
    public int Cargas;  
    public float CD;
}

public class CadaCarta : ScriptableObject
{
    public Sprite sprite;
    public string Nome;
    public string Descricao;
    public int QualidadeDeManufatura;
    public int AtributoEspecial;
}