using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class GetItems : MonoBehaviour
{
    //public TMP_Text OroTexto;
    //public TMP_Text BronceTexto;

    public int puntosVida;
    public int numMonedas;
    public int recuerdos;
    public HUD hud;
    public PlayerDataSO playerData;
    //public PlayerDataSO playerData;
    //public HUD
    // Start is called before the first frame update
    void start()
    {

    }
    void Update()
    {
        //OroTexto.text = numeroOro.ToString();
        //BronceTexto.text = numBronce.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "puntosVida")
        {
            Destroy(other.gameObject);
            playerData.puntosSanacion += 1;
            //puntosVida += 1;
            //playerData.puntosSanacion += puntosVida;
            Debug.Log("Puntos de Vida: " + playerData.puntosSanacion);
            //hud.SetNumPuntosVida(puntosVida);
        }

        if (other.tag == "monedas")
        {
            Destroy(other.gameObject);
            playerData.monedas += 1;
            //numMonedas += 1;
            Debug.Log("Número de monedas: " + playerData.monedas);
            //hud.SetNumMonedas(numMonedas);
        }
        if (other.tag == "recuerdos")
        {
            Destroy(other.gameObject);
            //recuerdos += 1;
            playerData.recuerdos += 1;
            Debug.Log("Número de recuerdos: " + playerData.recuerdos);
            //hud.SetNumRecuerdos(recuerdos);
        }
    }
}
