using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SliderLife : MonoBehaviour
{
    //public Caida caidaScript;
    public int vidas = 3;
    public int vidaMax;
    public int ataque = 1;
    public float vidaActual;
    public Image imagenBarraVida;
    public PlayerDataSO playerData;
    public HUD hud;

    // Start is called before the first frame update
    void Start()
    {
        //vidaActual = vidaMax;
        hud.SetNumVidas(vidas);
        playerData.puntosVidas = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
        //caidaScript.checaVida();
        //hud.SetNumVidas(vidas);

        if (Input.GetKeyDown(KeyCode.L))
        {
            if(playerData.puntosSanacion > 0)
            {
                playerData.puntosVidas = playerData.puntosVidas+playerData.puntosSanacion;
                playerData.puntosSanacion -= 1;
                hud.SetNumPuntosVida(playerData.puntosSanacion);
            }
        }

    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("ataqueMuerto"))
        {
            //vidaActual -= ataque;
            playerData.puntosVidas -= ataque;

            if (playerData.puntosVidas <= 0)
            {
                vidas -= 1;
                //caidaScript.lifes -= 1;
                //playerData.vidas -= 1;
                Debug.Log("VIDAS:" + playerData.vidas);


                if (vidas <= 0)
                {
                    //playerData.vidas = 3;
                    //playerData.puntosVidas = vidaMax;
                    SceneManager.LoadScene(0);

                }
                else
                {
                    playerData.puntosVidas = vidaMax;
                    hud.SetNumVidas(vidas);
                    SceneManager.LoadScene(1);
                }

                // HUD.Set
                //caidaScript.MoverPuntoInicial();
            }

        }
    }
    public void RevisarVida()
    {
        imagenBarraVida.fillAmount = playerData.puntosVidas / vidaMax;
    }
}

