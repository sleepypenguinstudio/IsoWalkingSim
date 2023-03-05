using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine.Rendering;
using System;
using DG.Tweening;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{


    public RectTransform panel1;
    public RectTransform panel2;
    public float transitionTime = 1f;

    private bool isTransitioning = false;
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


    public void NextPanel()
    {
        if (isTransitioning) return;

        isTransitioning = true;

        Vector2 startPos1 = panel1.anchoredPosition;
        Vector2 endPos1 = startPos1 - new Vector2(panel1.rect.width, 0);

        Vector2 startPos2 = panel2.anchoredPosition;
        Vector2 endPos2 = startPos2 - new Vector2(panel2.rect.width, 0);

        panel1.DOAnchorPos(endPos1, transitionTime)
            .OnComplete(() =>
            {
                panel1.gameObject.SetActive(false);
                panel2.gameObject.SetActive(true);
                panel2.anchoredPosition = startPos2;
                panel2.DOAnchorPos(endPos2, transitionTime)
                    .OnComplete(() =>
                    {
                        isTransitioning = false;
                    });
            });
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
