using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    public TargetsSpawner[] _spawners;
    public int allTargetCount = 0;

    private void Start()
    {
        
    }

    public void Check()
    {
        if (allTargetCount == 0) //Вместо 0 чтото надоЧЕМУТО
        {
        }

        Debug.Log(allTargetCount);
            //ВСЕ ЗАЕБУМБА КОЛ_ВО ВСЕХ МЕШЕНЕЙ СЮДА ПРИХОДИТ Осталось только проверять
    }
}
