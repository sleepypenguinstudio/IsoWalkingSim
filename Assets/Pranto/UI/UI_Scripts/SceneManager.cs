using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class SceneManager : MonoBehaviour
{
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
        Debug.Log("hg");
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
                mainMenuCamera.enabled = false;
                gameplayCamera.enabled = true;
                cinemachineBrain.enabled = true;
                gamePaused = false;
            }
            else
            {
                // Pause the game and switch to the main menu camera
                Time.timeScale = 0;
                mainMenuCamera.enabled = true;
                gameplayCamera.enabled = false;
                cinemachineBrain.enabled = false;
                gamePaused = true;
            }
        }
    }

    public void OnPlayButtonPressed()
    {
        // Switch to the gameplay camera
        Debug.Log("Play button pressed!");
        mainMenuCamera.enabled = false;
        gameplayCamera.enabled = true;
        cinemachineBrain.enabled = true;
    }

    public void OnQuitButtonPressed()
    {
        // Quit the game
        Application.Quit();
    }

}
