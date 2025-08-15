using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class HUD : MonoBehaviour
{
    public GameObject panelHUD;
    public TextMeshProUGUI vidasText;
    public TextMeshProUGUI recuerdosText;
    public TextMeshProUGUI puntosVidaText;
    public TextMeshProUGUI numMonedasText;
    public TextMeshProUGUI porcentajeVida;
    public TextMeshProUGUI porcentajePoder;
    public PlayerDataSO playerData;
    public int vidasProta = 3;
    // Start is called before the first frame update
    void Start()
    {
        /*
        if(playerData.vidas == 3)
        {
            SetNumVidas(playerData.vidas);
        }*/
        playerData.vidas = vidasProta;
        SetNumVidas(playerData.vidas);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetNumMonedas(int monedas)
    {
        playerData.monedas = monedas;
        numMonedasText.text = playerData.monedas.ToString();
        //numMonedasText.text = monedas.ToString();
        //armas.text = datos.GetNumArmas().ToString();
    }

    public void SetNumPuntosVida(int puntosVida)
    {
        playerData.puntosSanacion = puntosVida;
        puntosVidaText.text = playerData.puntosSanacion.ToString();
        //puntosVidaText.text = puntosVida.ToString();
    }

    public void SetNumRecuerdos(int numRecuerdos)
    {
        playerData.recuerdos = numRecuerdos;
        recuerdosText.text = playerData.recuerdos.ToString();
        //recuerdosText.text = numRecuerdos.ToString();
    }


    public void SetNumVidas(int numVidas)
    {
        //playerData.puntosVidas = numVidas;
        playerData.vidas = numVidas;
        vidasText.text = playerData.vidas.ToString();
        //vidasText.text = numVidas.ToString();
    }

    public void GetPuntosVida(float puntosVida)
    {
        playerData.puntosVidas = puntosVida;
    }
}
