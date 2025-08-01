using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menu_Inicial;
    //public GameObject menu_Ajustes;
    public GameObject menu_Creditos;
    // Start is called before the first frame update
    public GameObject menu_Ajustes;

    public GameObject menu_IniciarJuego;

    public GameObject creditos2;

    public GameObject creditos3;

    public Button playButton;
    public Button startButton;
    public Button resumeButton;
    public Button optionsButton;
    public Button creditsButton;
    public Button exitButton;
    public Button backFromOptionsButton;
    public Button backFromCreditsButton;
    public Button backFromStartGameButton;
    public Button nextCredits2Button;
    public Button nextCredits3Button;

    // Start is called before the first frame update
    void Start()
    {
        menu_Ajustes.SetActive(false);
        menu_IniciarJuego.SetActive(false);
        //playButton.onClick.AddListener(PlayGame);
        playButton.onClick.AddListener(showStartGame);
        startButton.onClick.AddListener(PlayGame);

        creditsButton.onClick.AddListener(showCredits);
        optionsButton.onClick.AddListener(showOptions);
        backFromCreditsButton.onClick.AddListener(showMain);
        backFromOptionsButton.onClick.AddListener(showMain);
        backFromStartGameButton.onClick.AddListener(showMain);
        nextCredits2Button.onClick.AddListener(showCredits2);
        nextCredits3Button.onClick.AddListener(showCredits3);
        showMain();
    }

    public void showStartGame()
    {
        CleanPanels();
        menu_IniciarJuego.SetActive(true);
    }
    public void showCredits()
    {
        CleanPanels();
        menu_Creditos.SetActive(true);
    }

    public void showCredits2()
    {
        CleanPanels();
        creditos2.SetActive(true);
    }
    public void showCredits3()
    {
        CleanPanels();
        creditos3.SetActive(true);
    }
    public void showOptions()
    {
        CleanPanels();
        menu_Ajustes.SetActive(true);
        //SoundMusicManager.InstanceMusic.PlayMenuAjustes();
    }

    public void showMain()
    {
        CleanPanels();
        menu_Inicial.SetActive(true);
        //SoundMusicManager.InstanceMusic.PlayMainMenu();


    }
    private void CleanPanels()
    {
        menu_Inicial.SetActive(false);
        menu_IniciarJuego.SetActive(false);
        menu_Ajustes.SetActive(false);
        menu_Creditos.SetActive(false);
        creditos2.SetActive(false);
        creditos3.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ResumeGame()
    {

    }

    public void Salir()
    {
        Application.Quit();
    }
}
