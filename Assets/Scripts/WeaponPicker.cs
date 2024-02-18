using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPicker : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;

    private void Start()
    {
        int selectedWeapon = Mathf.RoundToInt(Random.Range(0, weapons.Length));
        GameObject weapon = Instantiate(weapons[selectedWeapon], transform);
    }
}
