using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryRobot : Factory<AIController>
{
    [SerializeField] private float timer;
    [SerializeField] private float startTimer;

    private void Start()
    {
        startTimer = timer;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            GetNewInstance();
            timer = startTimer;
        }
    }
}
