using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public int highScore;
    public float speed;

    public void SetSpeed() 
    {
        speed = 3;
    }
}
