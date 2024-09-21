using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectEvents : MonoBehaviour
{
    public UnityEvent onDisable, onEnable;

    private void OnDisable()
    {
        onDisable.Invoke();
    }

    private void OnEnable()
    {
        onEnable.Invoke();
    }
}
