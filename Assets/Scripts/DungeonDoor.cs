using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Door))]
public class DungeonDoor : MonoBehaviour
{
    Door door;
    public int enemyCount = 5;
    public int enemiesKilled = 0;
    [SerializeField] GameObject[] nextRooms;
    [SerializeField] Animator[] traps;
    private void Start()
    {
        door = GetComponent<Door>();
    }

    private void Update()
    {
        if (enemiesKilled >= enemyCount)
        {
            int selectedRoom = Mathf.RoundToInt(Random.Range(0, nextRooms.Length));
            nextRooms[selectedRoom].SetActive(true);
            foreach (Animator trap in traps) trap.SetTrigger("Deactivate");
            door.Open();
            this.enabled = false;
        }
    }
}
