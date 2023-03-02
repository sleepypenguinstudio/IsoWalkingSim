using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class SceneManager : MonoBehaviour
{

    public Canvas canvas;
    public Stack<GameObject> panelStack = new Stack<GameObject>();
    public GameObject mainmenuvolume;
    public GameObject gameplayvolume;
    public CanvasGroup optionPanel;
    public CanvasGroup MainMenuPanel;
    public Camera mainMenuCamera;
    public Camera gameplayCamera;
    private CinemachineBrain cinemachineBrain;
    private bool gamePaused = false;
   




   
    void Start()
    {
        // Start with the main menu camera enabled and the gameplay camera disabled
        cinemachineBrain = gameplayCamera.GetComponent<CinemachineBrain>();

        mainMenuCamera.enabled = true;
        gameplayCamera.enabled = false;
        cinemachineBrain.enabled = false;
        
    }

    void Update()
    {
        // Check for the "Escape" key to pause/unpause the game and return to the main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                // Unpause the game and switch to the gameplay camera
                Time.timeScale = 1;
                canvas.gameObject.SetActive(false);
                gameplayCamera.enabled = true;
                cinemachineBrain.enabled = true;
                gamePaused = false;
            }
            else
            {
                // Pause the game and switch to the main menu camera
                Time.timeScale = 0;
                canvas.gameObject.SetActive(true);

                gamePaused = true;
            }
        }
    }



    public void PushPanel(GameObject panel)
    {
        if (panelStack.Count > 0)
        {
            panelStack.Peek().SetActive(false);
        }
        panelStack.Push(panel);
        panel.SetActive(true);

    }

    public void PopPanel()
    {
        if (panelStack.Count > 0)
        {
            GameObject previousPanel = panelStack.Pop();
            previousPanel.SetActive(false);
            if (panelStack.Count > 0)
            {
                panelStack.Peek().SetActive(true);
            }
        }
    }
    public void OnResumeButtonPressed()
    {
        Time.timeScale = 1;
       
        gameplayCamera.enabled = true;
        cinemachineBrain.enabled = true;
        gamePaused = false;
    }
    public void OnBackButtonPressed()
    {
        
        Debug.Log("Play button pressed!");
        mainMenuCamera.enabled = true;
        gameplayCamera.enabled = false;
        cinemachineBrain.enabled = false;
    }

    public void OnPlayButtonPressed()
    {

        mainmenuvolume.SetActive(false) ;
        gameplayvolume.SetActive(true);
        mainMenuCamera.enabled = false;
        gameplayCamera.enabled = true;
        cinemachineBrain.enabled = true;
    }


    public void OnOptionButtonPressed()
    {
 
        optionPanel.gameObject.SetActive(true) ;
        MainMenuPanel.gameObject.SetActive(false) ; 

    }
    public void BackButtonPressed()
    {

        optionPanel.gameObject.SetActive(false);
        MainMenuPanel.gameObject.SetActive(true);

    }
    public void OnQuitButtonPressed()
    {
        // Quit the game
        Application.Quit();
    }

}
