using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGame : MonoBehaviour
{

    public static ViewInGame sharedInstance;

    public Text carrotLabel;
    public Text distanceLabel;
    public Text maxDistanceLabel;

    void Awake()
    {
        sharedInstance = this;
    }

    void Update()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGameStarted)
        {
            distanceLabel.text = PlayerController.sharedInstance.RunningDistance().ToString("f0");  
        }
    }

    public void UpdateMaxDistanceLabel()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGameStarted)
        {
            maxDistanceLabel.text = PlayerPrefs.GetFloat("maxscore", 0).ToString("f0");
        } 
    }

    public void UpdateCarrotsLabel()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGameStarted)
        {
            carrotLabel.text = GameManager.sharedInstance.carrotCounter.ToString();
        }
    }
}
