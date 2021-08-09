using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Crear una enumeración de los estados del juego disponibles
public enum GameState { inMenu, inGameStarted, inGameOver, inGamePaused };

//Clase que se encargará de manejar todos los estados del juego
public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;

    //Crear una variable pública de tipo GameState para usarla como estado del juego actual.
    public GameState currentGameState;

    //--------------------------------------------------//

    private void Awake()
    {
        sharedInstance = this;
    }


    private void Start()
    {
        //Cuando el juego comience, el estado actual del juego será el del Menú Principal
        currentGameState = GameState.inMenu;
    }


    private void Update()
    {
        //Si el jugador pulsa la tecla S, el estado actual del juego pasará a estar en la pantalla de Juego.
        if (Input.GetKeyDown(KeyCode.S))
        {
            /*Si el estado actual del juego no es el de la pantalla de juego, 
                * coloca al personaje en su posición inicial, 
                * genera los bloques iniciales 
                * y cambia le estado del juego a "InGame"
           */
            if (currentGameState != GameState.inGameStarted)
            {
                PlayerController.sharedInstance.RestartPosition();
                LevelGenerator.sharedInstance.GenerateInitialBlocks();
                StartGame();
            }
        }

        //En el caso de que el jugador presiona la tecla de "ESC", se pausará la partida siempre y cuando el juego actual no esté en pausa ni haya terminado
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentGameState != GameState.inGamePaused && currentGameState != GameState.inGameOver)
            {
                PauseGame();
            }
        }

        //En el caso de que el jugador presione la tecla "K", matará al personaje y el estado de la partida cambiará a GameOver, siempre y cuando no se encuentre en ese estado.
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (currentGameState != GameState.inGameOver)
            {
               
                GameOver();
            }
        }
    }
    //--------------------------------------------------//

    //Método para cambiar el estado del juego en "comenzar el juego".
    public void StartGame()
    {
        
        ChangeState(GameState.inGameStarted);
       
    }

    //Método para cambiar el estado del juego en "juego terminado".
    public void GameOver()
    {
        LevelGenerator.sharedInstance.RemoveAllBlocks();
        ChangeState(GameState.inGameOver);
      
        
    }

    //Método para cambiar el estado del juego en "juego pausado".
    public void PauseGame()
    {
        ChangeState(GameState.inGamePaused);
    }

    //Método para volver al menú principal, y por lo tanto, cambiar su estado.
    public void ReturnToMainMenu()
    {
        ChangeState(GameState.inMenu);
    }

    //Método que cambia el estado del juego.
    void ChangeState(GameState newGameState)
    {
        //Si el nuevo estado del juego pertenece a que el juego ha comenzado, el estado del juego actual pasará a ser el nuevo estado del juego, asi sucesivamente...
        if (newGameState == GameState.inGameStarted)
        {
            currentGameState = newGameState;
        }
        else if (newGameState == GameState.inGameOver)
        {
            currentGameState = newGameState;
        }
        else if (newGameState == GameState.inGamePaused)
        {
            currentGameState = newGameState;
        }
        else if (newGameState == GameState.inMenu)
        {
            currentGameState = newGameState;
        }

    }
}

