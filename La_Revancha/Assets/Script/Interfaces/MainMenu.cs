using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menu_Inicial;
    public GameObject menu_Ajustes;
    public GameObject soundMenu;
    public GameObject imageMenu;
    public GameObject playMenu;
    public GameObject credits;
    public GameObject continueCredits;

    public Button playButton;
    public Button optionsButton;
    public Button soundButton;
    public Button imageButton;
    public Button beginButton;
    public Button resumeButton;
    public Button nextCredits;
    public Button creditsMenu;
    public Button exitGame;


    public Button backToMainMenuFromCredits;
    public Button backFromSoundButton;
    public Button backFromImageButton;
    public Button backToMainMenuFromSound;
    public Button backToMainMenuFromImage;





    /*
    public Button optionsButton;
    public Button creditsButton;
    public Button exitButton;
    public Button backFromOptionsButton;
    public Button backFromCreditsButton;
    public Button nextCredits2Button;
    public Button nextCredits3Button;
    */

    // Start is called before the first frame update
    void Start()
    {
        //menu_Ajustes.SetActive(false);
        playButton.onClick.AddListener(ShowBegin);
        beginButton.onClick.AddListener(PlayGame);

        optionsButton.onClick.AddListener(showOptions);
        soundButton.onClick.AddListener(showSoundMenu);
        imageButton.onClick.AddListener(showImageMenu);
        creditsMenu.onClick.AddListener(ShowCredits);
        nextCredits.onClick.AddListener(ShowNextCredits);

        backToMainMenuFromCredits.onClick.AddListener(showMain);
        backFromSoundButton.onClick.AddListener(showOptions);
        backFromImageButton.onClick.AddListener(showOptions);
        backToMainMenuFromSound.onClick.AddListener(showMain);
        backToMainMenuFromImage.onClick.AddListener(showMain);

        exitGame.onClick.AddListener(Salir);

        /*
        creditsButton.onClick.AddListener(showCredits);
        optionsButton.onClick.AddListener(showOptions);
        backFromCreditsButton.onClick.AddListener(showMain);
        backFromOptionsButton.onClick.AddListener(showMain);
        nextCredits2Button.onClick.AddListener(showCredits2);
        nextCredits3Button.onClick.AddListener(showCredits3);
        */
        showMain();
    }

    public void showOptions()
    {
        CleanPanels();
        menu_Ajustes.SetActive(true);
        //SoundMusicManager.InstanceMusic.PlayMenuAjustes();
    }


    public void ShowBegin()
    {
        CleanPanels();
        playMenu.SetActive(true);
    }

    public void ShowCredits()
    {
        CleanPanels();
        credits.SetActive(true);
    }

    public void ShowNextCredits()
    {
        CleanPanels();
        continueCredits.SetActive(true);
    }
    public void showMain()
    {
        CleanPanels();
        menu_Inicial.SetActive(true);
        //SoundMusicManager.InstanceMusic.PlayMainMenu();
    }


    public void showSoundMenu()
    {
        CleanPanels();
        soundMenu.SetActive(true);
    }

    public void showImageMenu()
    {
        CleanPanels();
        imageMenu.SetActive(true);
    }
    private void CleanPanels()
    {
        menu_Inicial.SetActive(false);
        menu_Ajustes.SetActive(false);
        soundMenu.SetActive(false);
        imageMenu.SetActive(false);
        playMenu.SetActive(false);
        credits.SetActive(false);
        continueCredits.SetActive(false);
}
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
