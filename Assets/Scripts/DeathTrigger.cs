using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que representa la zona de muerte
public class DeathTrigger : MonoBehaviour
{
    //Método que dispará un evento o acción al entrar en contacto con el GO que contenga este script
    private void OnTriggerEnter2D(Collider2D triggered)
    {
        //Si la etiqueta con la que entra el contacto el GO pertenece a la del personaje o jugador, El personaje muere
        if(triggered.tag == "Player")
        {
            PlayerController.sharedInstance.IsDead();
        }
    }
}
