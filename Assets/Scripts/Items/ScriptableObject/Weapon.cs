using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "ScpObject/Weapon")]
public class Weapon : ScriptableObject
{

    [SerializeField] private int _damage;
    [SerializeField] private float useStam;
    public GameObject WeaponPrefab;
    public GameObject UsedWeaponPrefab;
    public int Damage => _damage;
    public float UseStam => useStam;

    //переделать на float
}
