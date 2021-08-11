using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGameOver : MonoBehaviour
{

    public static ViewInGameOver sharedInstance;

    public Text carrotLabel;
    public Text distanceLabel;

    void Awake()
    {
        sharedInstance = this;
    }

    public void UpdateDistanceLabel()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGameOver)
        {
            distanceLabel.text = PlayerController.sharedInstance.RunningDistance().ToString("f0");
        } 
    }

    public void UpdateCarrotsLabel()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGameOver)
        {
            carrotLabel.text = GameManager.sharedInstance.carrotCounter.ToString();
        }
    }
}
