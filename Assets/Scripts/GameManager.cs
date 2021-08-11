using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Crear una enumeración de los estados del juego disponibles
public enum GameState { inMenu, inGameStarted, inGameOver, inGamePaused };


//Clase que se encargará de manejar todos los estados del juego
public class GameManager : MonoBehaviour
{
    //Crear una variable pública de tipo GameState para usarla como estado del juego actual.
    public GameState currentGameState;

    public static GameManager sharedInstance;

    //UI con el canvas de cada estado de juego
    public Canvas menuCanvas;
    public Canvas gameOverCanvas;
    public Canvas pauseCanvas;
    public Canvas gameStartedCanvas;

    //Variables para la puntuación del juego
    public int carrotCounter = 0;
    //--------------------------------------------------//

    private void Awake() {
        sharedInstance = this;
        
    }

    private void Start()
    {
        //Cuando el juego comience, el estado actual del juego será el del Menú Principal
        currentGameState = GameState.inMenu;
    }


    private void Update()
    {
        //En el caso de que el jugador presiona la tecla de "ESC", se pausará la partida siempre y cuando el juego actual no esté en pausa ni haya terminado
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentGameState == GameState.inGameStarted)
            {
                PauseGame();
            }
        }
    }
    //--------------------------------------------------//

    //Método para cambiar el estado del juego en "comenzar el juego".
    public void StartGame()
    {
        carrotCounter = 0;
        FakeBlock.sharedInstance.fakeBlock.SetActive(true);
        ChangeState(GameState.inGameStarted);
        
        ViewInGame.sharedInstance.UpdateCarrotsLabel();
        ViewInGame.sharedInstance.UpdateMaxDistanceLabel();
        


    }

    //Método para cambiar el estado del juego en "juego terminado".
    public void GameOver()
    {
        LevelGenerator.sharedInstance.RemoveAllBlocks();
        ChangeState(GameState.inGameOver);
        
        ViewInGameOver.sharedInstance.UpdateDistanceLabel();
        ViewInGameOver.sharedInstance.UpdateCarrotsLabel();
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
        LevelGenerator.sharedInstance.RemoveAllBlocks();
        PlayerController.sharedInstance.myAnimator.SetBool("isAlive", true);
        PlayerController.sharedInstance.RestartPosition();
        FakeBlock.sharedInstance.fakeBlock.SetActive(true);
       


    }

    //Método que cambia el estado del juego.
    void ChangeState(GameState newGameState)
    {
        //Si el nuevo estado del juego pertenece a que el juego ha comenzado, el estado del juego actual pasará a ser el nuevo estado del juego, asi sucesivamente...
        if (newGameState == GameState.inGameStarted)
        {
            currentGameState = newGameState;

            menuCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            pauseCanvas.enabled = false;
            gameStartedCanvas.enabled = true;

            gameStartedCanvas.gameObject.SetActive(true);
            

        }
        else if (newGameState == GameState.inGameOver)
        {
            currentGameState = newGameState;

            menuCanvas.enabled = false;
            gameStartedCanvas.enabled = false;
            pauseCanvas.enabled = false;
            gameOverCanvas.enabled = true;

            gameOverCanvas.gameObject.SetActive(true);
           
        }
        else if (newGameState == GameState.inGamePaused)
        {
            currentGameState = newGameState;

            menuCanvas.enabled = false;
            gameStartedCanvas.enabled = true;
            pauseCanvas.enabled = true;

            pauseCanvas.gameObject.SetActive(true);
            
        }
        else if (newGameState == GameState.inMenu)
        {
            currentGameState = newGameState;

            gameOverCanvas.enabled = false;
            pauseCanvas.enabled = false;
            gameStartedCanvas.enabled = false;
            menuCanvas.enabled = true;

            


        }

    }

    public void CountCarrots()
    {
        carrotCounter++;
        ViewInGame.sharedInstance.UpdateCarrotsLabel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}

