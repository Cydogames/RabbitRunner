using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject itemCollected;
    public bool isCollected = false;

    void ShowCoin()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<PolygonCollider2D>().enabled = true;
    }

    void HideCoin()
    {
        Destroy(itemCollected);
    }

    void CollectCoin()
    {
        isCollected = true;
        HideCoin();
        //Puntuación en el gamemanager
        GameManager.sharedInstance.CountCarrots();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CollectCoin();
        }
    }
}
