using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private DateTime _sessionStartTime;
    private DateTime _sessionEndTime;

    // Unity Event
    private void Start()
    {
        // TODO:
        // - Load player save
        // - If no save, direct player to registration scene
        // - Call backend and get daily challenge and rewards

        _sessionStartTime = DateTime.Now;
        Debug.Log("Game session start @:" + _sessionStartTime);
    }

    // Unity Event
    private void OnApplicationQuit()
    {
        
    }
}
