using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderLife : MonoBehaviour
{
    //public Caida caidaScript;
    public int vidaMax;
    public int ataque = 1;
    public float vidaActual;
    public Image imagenBarraVida;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
        //caidaScript.checaVida();

    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Enemigo"))
        {
            vidaActual -= ataque;

            if (vidaActual <= 0)
            {
                //caidaScript.lifes -= 1;
                vidaActual = vidaMax;
                //caidaScript.MoverPuntoInicial();
            }

        }
    }
    public void RevisarVida()
    {
        imagenBarraVida.fillAmount = vidaActual / vidaMax;
    }
}

