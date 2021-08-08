using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator sharedInstance; //Instancia compartida para tener un solo generado de niveles
    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>(); //Lista que contiene todos los niveles que se han creado
    public List<LevelBlock> currentLevelBlocks = new List<LevelBlock>(); //Lista que contiene los bloques que hay ahora mismo en pantalla.

    public Transform levelInitialPoint; //Punto inicial donde empezará a crearse el primer nivel de todos

    //--------------------------------------------------//

    private void Awake()
    {
        sharedInstance = this;
        AddNewBlock();
        AddNewBlock();

    }


    void Start()
    {
        GenerateInitialBlocks();
    }

    
    void Update()
    {
        
    }

    //--------------------------------------------------//

    public void AddNewBlock()
    {
        //Selecciona un bloque aleatorio de la lista disponible

        int randomIndex = Random.Range(0, allTheLevelBlocks.Count);

        LevelBlock block = (LevelBlock)Instantiate(allTheLevelBlocks[randomIndex]);

        block.transform.SetParent(this.transform, false);

        //POSICION DEL BLOQUE

        Vector3 blockPosition = Vector3.zero;

        if (currentLevelBlocks.Count == 0)
        {
            //Vamos a colocar el primer bloque en pantalla
            blockPosition = levelInitialPoint.position;
        } 
        else
        {
            //Ya tengo bloques en pantalla, lo empalmo al último disponible
            blockPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].exitPoint.position;
        }

        block.transform.position = blockPosition;
        currentLevelBlocks.Add(block);
    }

    public void RemoveOldBlock()
    {
        LevelBlock block = currentLevelBlocks[0];
        currentLevelBlocks.Remove(block);
        Destroy(block.gameObject);
    }

    public void GenerateInitialBlocks()
    {
        for (int i = 0; i < 3; i++)
        {
            AddNewBlock();
        }
    }
}
