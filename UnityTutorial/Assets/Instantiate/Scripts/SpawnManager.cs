using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<Unit> listsunits;
    [SerializeField] Factory factory;


    private void Start()
    {
        StartCoroutine(CreateRoutine());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LogRoutine());
        }
    }

    public IEnumerator CreateRoutine()
    {
        while (true)
        {
            // Random.Range : 0 ~ �ִ� -1�� ���� ��ȯ�ϴ� �Լ�
            factory.CreateUnit(listsunits[Random.Range(0, listsunits.Count)]);
            Debug.Log("����");
            yield return new WaitForSeconds(5f); // Ư���� �ð����� �ڷ�ƾ ���
        }
    }

    public IEnumerator LogRoutine()
    {
        yield return new WaitForSeconds(1f);

        Debug.Log("Attack");
    }
    
}
