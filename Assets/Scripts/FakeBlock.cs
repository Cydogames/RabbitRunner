using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBlock : MonoBehaviour
{
    public static FakeBlock sharedInstance;

    public GameObject fakeBlock;

    private void Awake()
    {
        sharedInstance = this;
    }

}
