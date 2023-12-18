using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject unit;
    [SerializeField] Transform createPosition1;

    [Tooltip("������ ������ �ִ�")]
    [SerializeField] int createCount = 5;




    private void Start()
    {
        // Instantiate : ���� ������Ʈ�� �����ϴ� �Լ�.
        for (int i = 0; i < createCount; i++)
        {
            // 1. ���� ������Ʈ ����
            GameObject monster = Instantiate(unit, createPosition1); // monster ��� �̸��� ���������� �����.

            // 2. ������ ���� ������Ʈ�� ��ġ�� �����մϴ�.
            monster.transform.position = new Vector3 (i*5, 0, createPosition1.position.z);

            Debug.Log("world pos : " + monster.transform.position);
            Debug.Log("local pos : " + monster.transform.localPosition);
        }
    }

}
