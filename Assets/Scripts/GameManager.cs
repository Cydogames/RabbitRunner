using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { inMenu, inGameStarted, inGameOver, inGamePaused };

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public GameState currentGameState;

    //--------------------------------------------------//

    private void Awake()
    {
        sharedInstance = this;
    }


    private void Start()
    {
        currentGameState = GameState.inMenu;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentGameState != GameState.inGameStarted)
            {

                StartGame();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentGameState != GameState.inGamePaused)
            {
                PauseGame();

                if (Input.GetKeyDown(KeyCode.M))
                {
                    ReturnToMainMenu();
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (currentGameState != GameState.inGameOver)
            {

                GameOver();
            }
        }

        //--------------------------------------------------//

        void StartGame()
        {
            currentGameState = GameState.inGameStarted;
        }

        void GameOver()
        {
            currentGameState = GameState.inGameOver;
        }

        void PauseGame()
        {
            currentGameState = GameState.inGamePaused;
        }

        void ReturnToMainMenu()
        {
            currentGameState = GameState.inMenu;
        }
    }
}
