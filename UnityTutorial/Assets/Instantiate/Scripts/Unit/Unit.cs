using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Move,
    Attack,
    Die,
    None
}

public abstract class Unit : MonoBehaviour
{
    [SerializeField] GameObject target;

    [SerializeField] State state;

    [SerializeField] Animator animator;
    [SerializeField] Vector3 direction;
    [SerializeField] Vector3 targetDirection;

    [SerializeField] float speed = 5.0f;
    [SerializeField] protected float health;

    [SerializeField] Sound sound = new Sound();

    public void OnHit(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            state = State.Die;
        }
    }

    public virtual void Release()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        target = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        switch (state)
        {
            case State.Move:
                Move();
                break;
            case State.Attack:
                Attack();
                break;
            case State.Die:
                Die();
                break;
        }
    }

    public virtual void Move()
    {
        animator.SetBool("Attack", false);

        // 1. Target의 벡터 - 자신의 위치 벡터
        direction = target.transform.position - transform.position;
        targetDirection = target.transform.position;

        // 2. y축을 0으로 설정합니다.
        direction.y = 0;
        targetDirection.y = 0;

        // 3. 벡터의 정규화
        direction.Normalize();

        // 4. 특정한 대상을 바라봅니다.
        transform.LookAt(targetDirection);

        // 5. 방향 벡터를 구한 값을 가지고 이동을 합니다.
        transform.position += direction * speed * Time.deltaTime;
    }

    public virtual void Attack()
    {
        
        animator.SetBool("Attack", true);
    }

    public void AttackSound()
    {
        SoundManager.instance.Sound(sound.audioClips[0]);
    }

    public virtual void Die()
    {
        animator.Play("Die");
        SoundManager.instance.Sound(sound.audioClips[1]);

        state = State.None;
    }

    // OnTriggerEnter() : Trigger 충돌이 되었을 때 이벤트를 호출하는 함수입니다.
    private void OnTriggerEnter(Collider other)
    {
        state = State.Attack;
    }

    // OnTriggerStay() : Trigger가 충돌 중일 때 이벤트를 호출하는 함수입니다.
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    // OnTriggerExit() : Trigger와 충돌이 끝났을 때 이벤트를 호출하는 함수입니다.
    private void OnTriggerExit(Collider other)
    {
        state = State.Move;
    }
}
