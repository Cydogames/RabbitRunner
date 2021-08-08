using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveBlockTrigger : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D triggered)
    {
        if (triggered.tag == "Player")
        {
            LevelGenerator.sharedInstance.AddNewBlock();
            LevelGenerator.sharedInstance.RemoveOldBlock();
        }
    }
}
