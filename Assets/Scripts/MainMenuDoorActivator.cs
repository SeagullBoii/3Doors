using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuDoorActivator : MonoBehaviour
{
    [SerializeField] Door door;
    [SerializeField] MainMenuDoorActivator[] otherDoors;
    [SerializeField] GameObject rooms;
    private void OnTriggerEnter(Collider other)
    {
        foreach (MainMenuDoorActivator door in otherDoors) { 
            door.enabled = false;
            door.gameObject.SetActive(false);
        }

        rooms.SetActive(true);
        door.Open();
    }
}
