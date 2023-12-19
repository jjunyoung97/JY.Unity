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
            // Random.Range : 0 ~ 최댓값 -1의 값을 반환하는 함수
            factory.CreateUnit(listsunits[Random.Range(0, listsunits.Count)]);
            Debug.Log("생성");
            yield return new WaitForSeconds(5f); // 특정한 시간동안 코루틴 대기
        }
    }

    public IEnumerator LogRoutine()
    {
        yield return new WaitForSeconds(1f);

        Debug.Log("Attack");
    }
    
}
