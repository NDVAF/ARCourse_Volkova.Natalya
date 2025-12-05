using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("ARCourse/Message Logger")]
public class MessageLogger : MonoBehaviour
{
    [SerializeField] private string _massage = "Default message";
    [ContextMenu("LogMessageTest")]
    public void LogMessage()
    {
        Debug.Log(_massage);
    }
}
