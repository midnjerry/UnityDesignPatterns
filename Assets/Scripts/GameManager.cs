using System;
using System.Text.RegularExpressions;
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
        int width = 300;
        GUI.color = Color.black;
        GUIStyle titleStyle = new GUIStyle();
        titleStyle.fontSize = 24;
        titleStyle.alignment = TextAnchor.UpperCenter;
        GUI.Label(new Rect((Screen.width - width) / 2, 0, width, 50), "Current Scene: " + ConvertFromPascalCaseToSpaces(SceneManager.GetActiveScene().name), titleStyle);
        
        GUI.color = Color.white; 
        GUILayout.BeginArea(new Rect(Screen.width - 100, 0, 100, 50));
        if (GUILayout.Button("Next Scene"))
        {
            // On button push, load next scene loaded in scene array.
            int lastIndex = SceneManager.sceneCountInBuildSettings - 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex % lastIndex + 1) ;
        }        
        GUILayout.EndArea();        
    }

    private string ConvertFromPascalCaseToSpaces(string input)
    { 
        return Regex.Replace(input, "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", " $1").Trim();
    }
}
