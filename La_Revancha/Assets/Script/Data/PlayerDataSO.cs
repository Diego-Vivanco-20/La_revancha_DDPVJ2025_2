using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{
    public int vidas;
    public int recuerdos;
    public int monedas;
    public int puntosSanacion;
    public float puntosVidas;
    public float puntosPoder;
    
}
