using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PauseMenu : MonoBehaviour
{

    public GameObject GrupoMenuPausa;
    public GameObject MenuAjustes;
    public GameObject HUD;
    public GameObject GameOver;
    //public GameObject Credits;

    public Button botonAjustes;
    public Button regresarMenuPausa;
    public Button continuar;
    public Button salir;
    public Button menuInicio;
    public Button reinicio;

    public bool pausa = false;

    // Start is called before the first frame update
    void Start()
    {
        GrupoMenuPausa.SetActive(false);
        MenuAjustes.SetActive(false);
        GameOver.SetActive(false);
        //LimpiarPaneles();
        botonAjustes.onClick.AddListener(Ajustes);
        regresarMenuPausa.onClick.AddListener(Reanudar);
        continuar.onClick.AddListener(Reanudar);
        salir.onClick.AddListener(Salir);
        reinicio.onClick.AddListener(Reinicio);



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausa = !pausa;

            if (pausa)
            {
                HUD.SetActive(false);
                GrupoMenuPausa.SetActive(true);
                pausar();
                //pausa = true;

                /*Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;*/
            }
            else
            {
                Reanudar();
            }
        }

    }

    public void pausar()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Reanudar()
    {
        MenuAjustes.SetActive(false);
        HUD.SetActive(true);
        //ControladorOpciones.SetActive(false);
        GrupoMenuPausa.SetActive(false);
        //pausa = false;

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }


    public void Reinicio()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Ajustes()
    {
        GrupoMenuPausa.SetActive(false);
        HUD.SetActive(false);
        MenuAjustes.SetActive(true);
    }



    public void irMenuInicio(string nombreMenu)
    {
        SceneManager.LoadScene(nombreMenu);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
