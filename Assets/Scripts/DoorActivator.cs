using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivator : MonoBehaviour
{
    [SerializeField] Door door;
    [SerializeField] Function function = Function.Open;
    enum Function
    {
        Open, Close
    }

    private void OnTriggerEnter(Collider other)
    {
        if (function == Function.Open) door.Open();
        else door.Close();
        
        this.enabled = false;

    }
}
