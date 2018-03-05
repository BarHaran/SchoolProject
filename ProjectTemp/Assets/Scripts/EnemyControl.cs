using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    public NavMeshAgent agent;

    int health;
    int speed;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (agent.remainingDistance < 1)
        {
            Destroy(gameObject);
        }
    }

    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }
}
