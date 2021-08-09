using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que permite disparar una acci�n al cruzarse con cualquier objeto que se encuentre
public class LeaveBlockTrigger : MonoBehaviour
{
    //M�todo que disparar� una acci�n al entrar en contacto el GO que almacene este script con cualquier objeto que se cruce con su camino
    private void OnTriggerEnter2D(Collider2D triggered)
    {
        //Una vez que cualquier objeto se encuentre con el trigger, a�adir un nuevo bloque.
        LevelGenerator.sharedInstance.AddNewBlock();

        //Una vez que cualquier objeto se encuentre con el trigger, eliminar los bloques antiguos
        LevelGenerator.sharedInstance.RemoveOldBlock();

    }
}
