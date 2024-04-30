using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyGoalController : MonoBehaviour
{
    public UnityEvent onTriggerEntered;
    private void OnTriggerEnter(Collider other)
    {
        onTriggerEntered.Invoke();
        Debug.Log("Goal!!!!");
    }
}
