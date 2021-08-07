using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D triggered)
    {
        if(triggered.tag == "Player")
        {
            PlayerController.sharedInstance.IsDead();
        }
    }
}
