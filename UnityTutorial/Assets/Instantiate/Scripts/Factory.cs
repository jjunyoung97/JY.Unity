using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] Transform spawnPosition;
    public GameObject CreateUnit(Unit unit)
    {
        // 1. ���� ������Ʈ ����
        GameObject monster = Instantiate(unit.gameObject, spawnPosition);

        // 2. ���� ������Ʈ ��ȯ
        return monster;
    }
}
