using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 100;
    private int speed = 5;

    public void Start()
    {
        Debug.Log("hp : " + hp);
    }
}
