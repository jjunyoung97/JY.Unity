using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject unit;
    [SerializeField] Transform createPosition1;

    [Tooltip("생성할 몬스터의 최댓값")]
    [SerializeField] int createCount = 5;




    private void Start()
    {
        // Instantiate : 게임 오브젝트를 생성하는 함수.
        for (int i = 0; i < createCount; i++)
        {
            // 1. 게임 오브젝트 생성
            GameObject monster = Instantiate(unit, createPosition1); // monster 라는 이름의 참조변수를 만든다.

            // 2. 생성된 게임 오브젝트의 위치를 설정합니다.
            monster.transform.position = new Vector3 (i*5, 0, createPosition1.position.z);

            Debug.Log("world pos : " + monster.transform.position);
            Debug.Log("local pos : " + monster.transform.localPosition);
        }
    }

}
