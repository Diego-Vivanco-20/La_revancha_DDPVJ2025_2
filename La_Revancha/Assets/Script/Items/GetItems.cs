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
    public int monedas;
    public int recuerdos;
    public HUD hud;
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
            puntosVida += 1;
            Debug.Log("Puntos de Vida: " + puntosVida);
            hud.SetNumPuntosVida(puntosVida);
        }

        if (other.tag == "monedas")
        {
            Destroy(other.gameObject);
            monedas += 1;
            Debug.Log("Número de monedas: " + monedas);
            hud.SetNumMonedas(monedas);
        }
        if (other.tag == "recuerdos")
        {
            Destroy(other.gameObject);
            monedas += 1;
            Debug.Log("Número de recuerdos: " + recuerdos);
            hud.SetNumRecuerdos(recuerdos);
        }
    }
}
