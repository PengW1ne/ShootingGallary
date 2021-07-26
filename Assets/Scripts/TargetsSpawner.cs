using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class TargetsSpawner : MonoBehaviour
{
    private Transform startPoint;
    private GameOverChecker _gameOverChecker;
    private GameObject[] targetClone;
    private float TimeUntilNextSpawn;
    private int wayIndex = 0;
    private int targetLength;
    private int count;
    

    public GameObject targetpf;
    public Transform[] wayPoints;
    public float moveSpeed;
    public float period;
    public int targetCount;


    void Start()
    {
        _gameOverChecker = FindObjectOfType<GameOverChecker>();
        TimeUntilNextSpawn = Random.Range(0, period);
        targetLength = 0;
        targetClone = new GameObject[targetCount];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        TimeUntilNextSpawn -= Time.deltaTime;
        if (targetCount != 0)
        {
            if (TimeUntilNextSpawn <= 0.0f)
            {
                TimeUntilNextSpawn = period;

                startPoint = wayPoints[wayIndex];

                targetClone[targetLength] = Instantiate(targetpf, startPoint);
                targetLength++;
                targetCount--;
            }
        }

        Move();
    }

    void Move()
    {
        for (int i = 0; i < targetClone.Length; i++)
        {
            if (targetClone[i] != null)
            {
                targetClone[i].transform.position =
                    Vector3.MoveTowards(targetClone[i].transform.position,
                        wayPoints[wayIndex].transform.position,
                        moveSpeed * Time.deltaTime);
                if (targetClone[i].transform.position == wayPoints[wayIndex].position)
                {
                    wayIndex++;
                }

                if (wayIndex == wayPoints.Length)
                {
                    Destroy(targetClone[i]);
                    _gameOverChecker.allTargetCount++;
                    _gameOverChecker.Check();
                    wayIndex = 0;
                }
            }
        }
        
    }
}