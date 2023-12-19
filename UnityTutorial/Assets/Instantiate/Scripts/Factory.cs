using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] Transform spawnPosition;
    public GameObject CreateUnit(Unit unit)
    {
        // 1. 게임 오브젝트 생성
        GameObject monster = Instantiate(unit.gameObject, spawnPosition);

        // 2. 게임 오브젝트 반환
        return monster;
    }
}
