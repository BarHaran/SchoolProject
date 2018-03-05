using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyGenerator : MonoBehaviour
{
    Dictionary<GameObject, float[]> wave;

    float wavetime;
    bool working;

    public GameObject[] Enemies;

    Vector3 player1start;
    Vector3 player1end;

    Vector3 player2start;
    Vector3 player2end;

    private void Start()
    {
        CreateWave();

        player1start = transform.Find("Player1Enemies").position;
        player1end = GameObject.Find("Player1Map").transform.Find("Base").position;
        player2start = transform.Find("Player2Enemies").position;
        player2end = GameObject.Find("Player2Map").transform.Find("Base").position;

        working = true;
    }

    private void Update()
    {
        if (working)
        {
            wavetime += Time.deltaTime;
            if (wavetime < 30)
            {
                foreach (KeyValuePair<GameObject, float[]> enemytype in wave)
                {
                    StartCoroutine(Spawn(enemytype.Key, enemytype.Value[1]));
                }
            }
            else
            {
                StopAllCoroutines();
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                {
                    working = false;
                    Debug.Log(working);
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                working = true;
                GameManager.Wave++;
                CreateWave();
                wavetime = 0;

            }
        }
    }

    void CreateWave()
    {
        float[] time1 = new float[GameManager.Wave < 11 ? GameManager.Wave + 9 : 20];
        for (int i = 0; i < time1.Length; i++)
        {
            time1[i] = (float)Math.Round((decimal)((30 / time1.Length) * (i + 1)), 1);
        }
        wave = new Dictionary<GameObject, float[]>();
        wave.Add(Enemies[0], time1);
        foreach (var f in time1)
        {
            Debug.Log(f);
        }
    }

    IEnumerator Spawn(GameObject Enemy, float RepeatRate)
    {
        GameObject enemy1 = Instantiate(Enemy, player1start, new Quaternion());
        enemy1.GetComponent<EnemyControl>().agent.destination = player1end;
        GameObject enemy2 = Instantiate(Enemy, player2start, new Quaternion());
        enemy2.GetComponent<EnemyControl>().agent.destination = player2end;
        yield return new WaitForSecondsRealtime(RepeatRate);
    }
}
