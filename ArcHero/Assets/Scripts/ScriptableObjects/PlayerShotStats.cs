using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerShotStat", menuName = "ScriptableObjects/PlayerStats/PlayerShotStat")]
public class PlayerShotStats : ScriptableObject
{
    [Tooltip("Arrow speed")]
    public float DefaultShotSpeed=100;
    [Tooltip("Arrow shot frequency")]
    public float DefaultShotFrequency=2;
    [Tooltip("How many arrow can player shot")]
    public int DefaultShotAmount=1;
    [Tooltip("How many seconds will be waited between Consecutive Shots")]
    public float ConsecutiveShotInterval = .1f;
    [Tooltip("Direction of the arrows that shots")]
    public List<Vector3> Directions = new List<Vector3> { Vector3.zero};

}