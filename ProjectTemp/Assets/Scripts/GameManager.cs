using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Wave
    {
        get { return wave; }
        set { wave = value; }
    }

    static int wave;

    // Use this for initialization
    void Start()
    {
        wave = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
