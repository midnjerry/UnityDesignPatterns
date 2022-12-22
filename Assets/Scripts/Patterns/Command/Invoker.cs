using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Chapter.Command
{
    public class Invoker : MonoBehaviour
    {
        private bool _isRecording;
        private bool _isReplaying;
        private float _replayTime;
        private float _recordingTime;
        private int counter = 0;
        private SortedList<float, Command> _recordedCommands = new SortedList<float, Command>();

        public void ExecuteCommand(Command command)
        {
            command.Execute();

            if (_isRecording)
            {
                _recordedCommands.Add(_recordingTime, command);
                Debug.Log("Recorded Time: " + _recordingTime + " Command: " + command);
            }
        }

        public void Record()
        {
            _recordedCommands.Clear();
            _recordingTime = 0.0f;
            _isRecording = true;
        }

        public void Replay()
        {
            counter = 0;
            _replayTime = 0.0f;
            _isReplaying = true;

            if (_recordedCommands.Count <= 0)
            {
                Debug.LogError("No commands to replay!");
            }

            _recordedCommands.Reverse();
        }

        public void StopReplay()
        {
            _isReplaying = false;
            Debug.Log("Stopping Replay");
        }

        private void FixedUpdate()
        {
            if (_isRecording)
            {
                _recordingTime += Time.fixedDeltaTime;
            }

            if (_isReplaying)
            {
                Debug.Log("Counter: " + counter + " ReplayTime: " + _replayTime);
                _replayTime += Time.deltaTime;
                if (counter < _recordedCommands.Count)
                {
                    // _replayTime > _recordedCommands.Keys[0] ||
                    if (Mathf.Approximately(_replayTime, _recordedCommands.Keys[counter]))
                    {
                        Debug.Log("Replay Time: " + _replayTime);
                        Debug.Log("Replay Command: " + _recordedCommands.Values[counter]);
                        _recordedCommands.Values[counter].Execute();
                        counter++;
                    }
                }
                else
                {
                    _isReplaying = false;                    
                }
            }
        }
    }
}