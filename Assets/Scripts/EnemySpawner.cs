using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float enemyCount;
    [SerializeField] GameObject[] enemies;
    List<int> selectedEnemies = new List<int>();
    bool spawned = false;
    private void OnTriggerEnter(Collider other)
    {
        if (spawned) return;
        if (enemyCount>enemies.Length)enemyCount=enemies.Length;
        print(enemyCount);
        for (int i = 0; i < enemyCount; i++)
        {
            int selectedEnemy = Mathf.RoundToInt(Random.Range(0, enemies.Length));
            while (selectedEnemies.Contains(selectedEnemy))
                selectedEnemy = Mathf.RoundToInt(Random.Range(0, enemies.Length));
            enemies[selectedEnemy].SetActive(true);
            selectedEnemies.Add(selectedEnemy);
            print(selectedEnemy);
        }
        spawned = true;
        this.enabled = false;
        Destroy(gameObject);
    }
}
