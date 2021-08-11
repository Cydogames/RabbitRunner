using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase representa al generador de niveles, la cual generará o eliminará un número determinado de bloques
public class LevelGenerator : MonoBehaviour
{
    //----------------------VARIABLES---------------------------//

    //Instancia compartida para tener un solo generados de niveles
    public static LevelGenerator sharedInstance;

    //Lista que contiene todos los niveles que se han creado
    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();

    //Lista que contiene los bloques que hay ahora mismo en pantalla.
    public List<LevelBlock> currentLevelBlocks = new List<LevelBlock>();

    //Punto inicial donde empezará a crearse el primer nivel de todos
    public Transform levelInitialPoint;

    private bool isGeneratingInitialBlocks = false;

    //----------------------METODOS DE UNITY---------------------------//


    private void Awake()
    {
        //La instancia compartida hace referencia a la propia clase "LevelGenerator" mediante la palabra reservada "this"
        sharedInstance = this;

        //Se añade dos nuevos bloques (Consultar el método definido mas abajo)
        for (int i = 0; i < 2; i++)
        {
            AddNewBlock();
        }

    }



    void Start()
    {
        //Si el estado actual del juego se encuentra en la partida comenzada, se generan los bloques iniciales
        if(GameManager.sharedInstance.currentGameState == GameState.inGameStarted)
        {
            GenerateInitialBlocks(); //Método definido mas abajo
        }
        
    }

    //----------------------METODOS PROPIOS---------------------------//

    //Método para añadir un nuevo bloque en la escena
    public void AddNewBlock()
    {
        //Selecciona un bloque aleatorio de la lista completa de bloques, dentro del rango disponible 
        int randomIndex = Random.Range(0, allTheLevelBlocks.Count);

        //Se instancia un bloque aleatorio de la lista, para ello se crea el objeto block de tipo LevelBlock
        LevelBlock block = Instantiate(allTheLevelBlocks[randomIndex]);

        /*
         * La transform del bloque se vincula a la del padre, en este caso LevelGenerator (this), 
         * y su posición tomará como referencia las coordenadas del padre y no las del mundo.
         */
        block.transform.SetParent(this.transform, false);

        //Establecer la posición inicial del bloque en sus coordenadas de origen.
        Vector3 blockPosition = Vector3.zero; // ó Vector3(0,0,0);

        
        
        
        
        
        //Si el conteo de la lista de bloques actuales en pantalla es 0, estableciendo la posición inicial donde nos interese
        if (currentLevelBlocks.Count == 0)
        {
            //Vamos a colocar el primer bloque en pantalla
            blockPosition = levelInitialPoint.position;
        } 
        //De lo contrario, si ya tengo bloques en pantalla, empalmo la posición del nuevo bloque con la posición final del último bloque en pantalla
        else
        {
            //Ya tengo bloques en pantalla, lo empalmo al último disponible
            blockPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].exitPoint.position;
        }

        //Se establece la posición del bloque instanciado anteriormente con su posición correspodiente
        block.transform.position = blockPosition;
        
        //Se añade este bloque a la lista de bloques actuales en pantalla
        currentLevelBlocks.Add(block);
    }

    //Método para generar los bloques iniciales (generar hasta dos bloques)
    public void GenerateInitialBlocks()
    {
        isGeneratingInitialBlocks = true;
        for (int i = 0; i < 3; i++)
        {
            AddNewBlock();
        }
        isGeneratingInitialBlocks = false;
    }

    //Método para eliminar los bloques antiguos de la escena (por los que ya ha pasado el personaje)
    public void RemoveOldBlock()
    {
        //Crear una variable tipo LevelBlock, almacenando la primera posición del bloque en la escena
        LevelBlock block = currentLevelBlocks[0];

        //Elimina el bloque de la lista, de manera que desaparecerá de la escena
        currentLevelBlocks.Remove(block);

        //Destruir el GameObject de ese bloque específica de la jerarquia.
        Destroy(block.gameObject);
    }

   
    //Método para eliminar todos los bloques de la escena
    public void RemoveAllBlocks()
    {
        //Mientras la cantidad de bloques sea mayor que 0, llamar ál método que elimina los bloques antiguos de la escena
        while (currentLevelBlocks.Count > 0)
        {
            RemoveOldBlock();
        }
    }
}
