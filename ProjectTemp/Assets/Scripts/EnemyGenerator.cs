using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Enemies;

    Vector3 player1start;
    Vector3 player1end;

    Vector3 player2start;
    Vector3 player2end;

    private void Start()
    {
        player1start = transform.Find("Player1Enemies").position;
        player1end = GameObject.Find("Player1Map").transform.Find("Base").position;
        player2start = transform.Find("Player2Enemies").position;
        player2end = GameObject.Find("Player2Map").transform.Find("Base").position;

        InvokeRepeating("Spawn", 1, 0.5f);
    }

    void Spawn()
    {
        GameObject enemy1 = Instantiate(Enemies, player1start, new Quaternion());
        enemy1.GetComponent<EnemyControl>().agent.destination = player1end;
        GameObject enemy2 = Instantiate(Enemies, player2start, new Quaternion());
        enemy2.GetComponent<EnemyControl>().agent.destination = player2end;
    }
}
