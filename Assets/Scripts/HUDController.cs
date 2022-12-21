using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    private bool _isDisplayOn;

    private void OnEnable()
    {
        RaceEventBus.Subscribe(RaceEventType.START, DisplayHUD);
    }

    private void OnDisable()
    {
        RaceEventBus.Subscribe(RaceEventType.STOP, DisplayHUD);
    }

    private void DisplayHUD()
    {
        _isDisplayOn = true;
    }

    private void OnGUI()
    {
        if (_isDisplayOn)
        {
            if (GUILayout.Button("Stop Race"))
            {
                _isDisplayOn = false;
                RaceEventBus.Publish(RaceEventType.STOP);
            }
        }
    }
}
