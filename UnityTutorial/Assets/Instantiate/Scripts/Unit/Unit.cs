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

        // 1. Target�� ���� - �ڽ��� ��ġ ����
        direction = target.transform.position - transform.position;
        targetDirection = target.transform.position;

        // 2. y���� 0���� �����մϴ�.
        direction.y = 0;
        targetDirection.y = 0;

        // 3. ������ ����ȭ
        direction.Normalize();

        // 4. Ư���� ����� �ٶ󺾴ϴ�.
        transform.LookAt(targetDirection);

        // 5. ���� ���͸� ���� ���� ������ �̵��� �մϴ�.
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

    // OnTriggerEnter() : Trigger �浹�� �Ǿ��� �� �̺�Ʈ�� ȣ���ϴ� �Լ��Դϴ�.
    private void OnTriggerEnter(Collider other)
    {
        state = State.Attack;
    }

    // OnTriggerStay() : Trigger�� �浹 ���� �� �̺�Ʈ�� ȣ���ϴ� �Լ��Դϴ�.
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    // OnTriggerExit() : Trigger�� �浹�� ������ �� �̺�Ʈ�� ȣ���ϴ� �Լ��Դϴ�.
    private void OnTriggerExit(Collider other)
    {
        state = State.Move;
    }
}
