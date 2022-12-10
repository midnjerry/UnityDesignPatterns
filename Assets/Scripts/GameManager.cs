using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        _sessionEndTime = DateTime.Now;
        TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime);
        Debug.Log("Game session lasted: " + timeDifference);
    }

    private void OnGUI()
    {
        if(GUILayout.Button("Next Scene"))
        {
            // On button push, load next scene loaded in scene array.
            int lastIndex = SceneManager.sceneCountInBuildSettings - 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex % lastIndex + 1) ;
        }
    }
}
