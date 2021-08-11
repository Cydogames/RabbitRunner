using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que representa los controles del jugador
public class PlayerController : MonoBehaviour
{
    public static PlayerController sharedInstance;

    //Se crea una variable Vector3 declarando la posici�n inicial del personaje
    public Vector3 startPosition; 

    //Variable de tipo decimal que representa la fuerza del salto
    public float jumpForce = 30.0f;

    //Variable decimal que representa la velocidad de movimiento horizontal
    public float runningSpeed = 5.0f;

    //Variable de tipo LayerMask que representa una capa determinada del objeto, en este caso el suelo 
    public LayerMask groundLayerMask;

    //Variable que hace referencia a las fisicas 2D del objeto
    private Rigidbody2D myRigidbody2d;

    //Variable que hacer referencia al componente de animaci�n del objeto
    public Animator myAnimator;

    private string playerMaxScore = "maxscore";

    //-------------------------------------------------------------//

    //M�todo en el que se preparan algunas opciones antes de empezar el juego
    private void Awake()
    {
        sharedInstance = this;

        //Inicializar la posici�n inicial correspondendiente a la posici�n de las coordenadas del personaje
        startPosition = this.transform.position;

        //Inicializar el objeto obteniendo el componente de las f�sicas
        myRigidbody2d = GetComponent<Rigidbody2D>();

        //Antes de empezar a jugar, programar la animaci�n del jugador para que se vea que est� vivo
        myAnimator.SetBool("isAlive", true);
    }

    public void Start()
    {
        myAnimator.SetBool("isAlive", true);
        RestartPosition();
    }

    private void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Jump();
            }
        }

        myAnimator.SetBool("isGrounded", IsGrounded());
    }


    private void FixedUpdate()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGameStarted && GameManager.sharedInstance.currentGameState != GameState.inMenu)
        {
            myAnimator.SetBool("isAlive", true);

            if (myRigidbody2d.velocity.x < runningSpeed)
            {
                myRigidbody2d.velocity = new Vector2(runningSpeed, myRigidbody2d.velocity.y);
            }
        } 
        else if (GameManager.sharedInstance.currentGameState == GameState.inGamePaused)
        {
            myRigidbody2d.velocity = new Vector2(0,0);
        }

        else if (GameManager.sharedInstance.currentGameState == GameState.inGameOver)
        {
        
            IsDead();
            myRigidbody2d.velocity = new Vector2(0, 0);
        }


    }

    //------------------------------------------------------------//

    //M�todo para reiniciar la posici�n del personaje
    public void RestartPosition()
    {
        //La posici�n del jugador corresponder� a su posici�n actual de inicio, representado por las coordenadas donde esta colocado el personaje en la escena
        this.transform.position = startPosition;

        //No tendr� velocidad
        myRigidbody2d.velocity = new Vector2(0, 0);
    }

    //M�todo para que el personaje salte siempre y cuando este en el suelo
    private void Jump()
    {
        if (IsGrounded())
        {
            //A las f�sicas del personaje se le suma una fuerza vertical hacia arriba multiplicado por la fuerza de salto, ejerciendo a su vez un impulso por inercia.
            myRigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }

    }

    //M�todo para comprobar si el personaje est� en el suelo
    private bool IsGrounded()
    {
        //Si el suelo esta a una distancia inferior de a 1 por debajo de la posici�n del personaje, determinar� que el personaje esta en el suelo
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, groundLayerMask.value))
        {
            return true;

        }
        else return false;
    }

    //M�todo para matar al personaje
    public void IsDead()
    {
        //La animaci�n del personaje pasa a la de muerte
        myAnimator.SetBool("isAlive", false);

        //Accediendo a la clase GameManager, mediante su instancia compartida, llamamos al m�todo que hace que la partida termine.
        GameManager.sharedInstance.GameOver();

        if (PlayerPrefs.GetFloat(playerMaxScore, 0) < this.RunningDistance())
        {
            PlayerPrefs.SetFloat(playerMaxScore, this.RunningDistance());
        }
    }

    //M�todo para calcular la distancia que el personaje est� recorriendo
    public float RunningDistance()
    {
        float distanceTravelled = Vector2.Distance(new Vector2(startPosition.x, 0), new Vector2(this.transform.position.x, 0));
        return distanceTravelled;
    }


}
